using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransactionSystems.Aggregator.Domain.UnitOfWork;
using TransactionSystems.Aggregator.Infrastructure.Persistence.UnitOfWork;

namespace TransactionSystems.Aggregator.Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWorkFactory(this IServiceCollection services)
        {
            return services
                .AddTransient<IUnitOfWorkFactory<ITransactionAggregatorUnitOfWork>, TransactionAggregatorUnitOfWorkFactory>();
        }

        public static IServiceCollection AddDatabase<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            return services.AddDbContextFactory<T>(options =>
                options.UseSqlServer(connectionString));
        }

        public static IServiceCollection AddMockDatabase<T>(this IServiceCollection services, string databaseName)
            where T : DbContext
        {
            return services.AddDbContextFactory<T>(options =>
                options.UseInMemoryDatabase(databaseName), ServiceLifetime.Transient);
        }
    }
}
