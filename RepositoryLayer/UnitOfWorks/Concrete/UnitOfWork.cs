using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RepositoryLayer.Context;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.Repository.Generic.Concrete;
using RepositoryLayer.UnitOfWorks.Abstract;

namespace RepositoryLayer.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        // savechange with concurrency exceptions catched
        public string Commit()
        {
            
            try
            {
                _context.SaveChanges();
                return string.Empty;
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateConcurrencyException)
                {
                    return "Data has just been changed by another User. Please Try Again.";
                }

                return ex.Message.ToString();
            }
        }

        // async savechange with concurrency exceptions catched
        public async Task<string> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return string.Empty;
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateConcurrencyException)
                {
                    return "Data has just been changed by another User. Please Try Again.";
                }

                return ex.Message.ToString();

            }

        }




        //dispose after commit
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        //transaction method
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }




        //brings all repositories via unitofworks
        IGenericRepository<T> IUnitOfWork.GetGenericRepository<T>()
        {
            return new GenericRepository<T>(_context);
        }


    }
}
