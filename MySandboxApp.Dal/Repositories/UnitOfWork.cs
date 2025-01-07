using Microsoft.EntityFrameworkCore;
using MySandBoxApp.Core.UnitOfWork;

namespace MySandboxApp.Dal.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : AppDbContext
    {
        private readonly TContext _context;
        private readonly Dictionary<Type, object?> _repositories;

        public UnitOfWork(TContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
