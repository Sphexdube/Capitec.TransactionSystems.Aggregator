using TransactionSystems.Aggregator.Infrastructure.DataSources.Extensions;

namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class DependencyRegistration
    {
        public static void Register(IServiceCollection services)
        {
            // Register core services
            services.AddDataSourceProviders();
            services.AddTransactionServices();
            services.AddCategorizationServices();

            // Add controllers
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });
        }

        private static IServiceCollection AddTransactionServices(this IServiceCollection services)
        {
            // Register transaction aggregation services
            // These will be implemented as we build out the solution
            return services;
        }

        private static IServiceCollection AddCategorizationServices(this IServiceCollection services)
        {
            // Register transaction categorization services
            // These will be implemented as we build out the solution
            return services;
        }
    }
}