using CoreLayer.BaseEntity;
using System.Linq.Expressions;

namespace RepositoryLayer.Repository.Generic.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        //signature of generic methods
        Task<T> GetEntityByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);




    }
}
