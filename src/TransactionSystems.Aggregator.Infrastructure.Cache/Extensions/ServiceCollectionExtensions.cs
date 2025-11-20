using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace TransactionSystems.Aggregator.Infrastructure.Cache.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            return services.AddMemoryCache(options =>
            {
                options.SizeLimit = 1024 * 1024; // 1MB default size limit
            });
        }
    }
}
