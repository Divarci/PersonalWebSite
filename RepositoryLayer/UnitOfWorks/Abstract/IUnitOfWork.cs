using CoreLayer.BaseEntity;
using Microsoft.EntityFrameworkCore.Storage;
using RepositoryLayer.Repository.Generic.Abstract;

namespace RepositoryLayer.UnitOfWorks.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        //signature of unit of work methods
        Task<string> CommitAsync();
        string Commit();
        Task<IDbContextTransaction> BeginTransactionAsync();
        IGenericRepository<T> GetGenericRepository<T>() where T : BaseEntity, new();
    }
}
