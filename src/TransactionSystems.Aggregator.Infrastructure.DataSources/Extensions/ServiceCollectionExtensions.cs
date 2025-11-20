using Microsoft.Extensions.DependencyInjection;
using TransactionSystems.Aggregator.Infrastructure.DataSources.MockDataSources;

namespace TransactionSystems.Aggregator.Infrastructure.DataSources.Extensions
{
    /// <summary>
    /// Extension methods for registering data source providers with the dependency injection container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all mock data source providers with the service collection.
        /// </summary>
        /// <param name="services">The service collection to add services to.</param>
        /// <returns>The service collection for method chaining.</returns>
        public static IServiceCollection AddDataSourceProviders(this IServiceCollection services)
        {
            // Register all mock data source providers
            services.AddSingleton<IDataSourceProvider, CapitecBankDataSource>();
            services.AddSingleton<IDataSourceProvider, StandardBankCreditCardDataSource>();
            services.AddSingleton<IDataSourceProvider, SnapScanDataSource>();
            services.AddSingleton<IDataSourceProvider, FNBBankDataSource>();

            return services;
        }
    }
}
