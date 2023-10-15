using CoreLayer.BaseEntity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Repository.Generic.Abstract;
using System.Linq.Expressions;

namespace RepositoryLayer.Repository.Generic.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        //Dependancy Injections
        protected readonly AppDbContext _context;
        private DbSet<T> _dbset;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }


        //All generic methods
        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
           
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            
            return _dbset.Where(expression);
        }

      
    }
}
