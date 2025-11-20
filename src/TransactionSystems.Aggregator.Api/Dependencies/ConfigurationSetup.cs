using TransactionSystems.Aggregator.Application.Models.Configuration;

namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class ConfigurationSetup
    {
        public static void AddApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind and register TransactionAggregatorConfiguration
            TransactionAggregatorConfiguration aggregatorConfiguration = new()
            {
                ApiTitle = configuration.GetValue<string>("ApplicationConfiguration:ApiTitle") ?? "Capitec TransactionSystems Aggregator API",
                ApiVersion = configuration.GetValue<string>("ApplicationConfiguration:ApiVersion") ?? "v1",
                Environment = configuration.GetValue<string>("ApplicationConfiguration:Environment") ??
                             configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") ?? "Development"
            };

            services.AddSingleton(aggregatorConfiguration);
        }
    }
}
