using Microsoft.EntityFrameworkCore;
using MySandBoxApp.Core.UnitOfWork;
using System.Linq.Expressions;

namespace MySandboxApp.Dal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AppDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet
                       .ToListAsync();
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);
            return item ?? throw new NullReferenceException($"Entity with ID = {id} not found.");
        }

        public virtual async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                       .Where(predicate)
                       .ToListAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var items = await _dbSet.ToListAsync();
            var entity = await _dbSet
                             .Where(entity => EF.Property<int>(entity, "Id") == id)
                             .FirstOrDefaultAsync();

            if (entity == null)
                throw new InvalidOperationException($"No entity found with ID {id} to delete.");

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
