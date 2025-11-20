using Microsoft.OpenApi.Models;

namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            DependencyRegistration.Register(services);
            return services;
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Capitec TransactionSystems Aggregator API",
                    Version = "v1",
                    Description = "API for aggregating customer financial transaction data from multiple sources and categorizing transactions.",
                    Contact = new OpenApiContact
                    {
                        Name = "Capitec TransactionSystems Team"
                    }
                });

                SwaggerRegistration.Register(options);
            });

            return services;
        }

        public static IServiceCollection AddHealthCheckServices(this IServiceCollection services)
        {
            // Add basic health checks
            services.AddHealthChecks();

            return services;
        }
    }
}
