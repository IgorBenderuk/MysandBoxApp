using Microsoft.EntityFrameworkCore;

namespace MySandBoxApp.Core.UnitOfWork
{
    public interface IUnitOfWork<out TContext> : IUnitOfWork where TContext : DbContext
    {
    }
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class;
    }
}
