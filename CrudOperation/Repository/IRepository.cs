using Microsoft.EntityFrameworkCore.Query;

namespace CrudOperation.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes);
        Task<T?> Get(long id);
        Task<T?> Insert(T entity);
        Task<T?> Update(T entity);
        Task Delete(long id);
        Task<bool> Remove(long id);
        Task SaveChanges();
    }
}
