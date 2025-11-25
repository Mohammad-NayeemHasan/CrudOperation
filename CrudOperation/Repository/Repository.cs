using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CrudOperation.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // -----------------------
        // Get All With Include
        // -----------------------
        public async Task<IEnumerable<T>> GetAll(
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (includes != null)
            {
                query = includes(query);
            }

            return await query.ToListAsync();
        }

        // -----------------------
        // Get by Id
        // -----------------------
        public async Task<T?> Get(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        // -----------------------
        // Insert
        // -----------------------
        public async Task<T?> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        // -----------------------
        // Update
        // -----------------------
        public async Task<T?> Update(T entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }

        // -----------------------
        // Delete using Find
        // -----------------------
        public async Task Delete(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        // -----------------------
        // Remove and return success/fail
        // -----------------------
        public async Task<bool> Remove(long id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            return true;
        }

        // -----------------------
        // Save changes
        // -----------------------
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }

}
