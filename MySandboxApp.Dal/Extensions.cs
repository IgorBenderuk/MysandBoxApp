using Microsoft.Extensions.DependencyInjection;
using MySandboxApp.Dal.Repositories;
using MySandBoxApp.Core.UnitOfWork;

namespace MySandboxApp.Dal
{
    public static class UnitOfWorkServiceCollectionExtension
    {
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : AppDbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
            return services;
        }

        public static IServiceCollection AddCustomRepository<TEntity, TRepository>(this IServiceCollection services)
            where TEntity : class
            where TRepository : class, IRepository<TEntity>
        {
            services.AddScoped<IRepository<TEntity>, TRepository>();

            return services;
        }
    }
}
