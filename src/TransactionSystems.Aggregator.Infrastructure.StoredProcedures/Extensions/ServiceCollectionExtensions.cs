using Microsoft.Extensions.DependencyInjection;
using TransactionSystems.Aggregator.Domain.Interfaces;

namespace TransactionSystems.Aggregator.Infrastructure.StoredProcedures.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStoredProcedureExecutor(this IServiceCollection services)
        {
            return services
                .AddTransient<IStoredProcedureExecutor, DapperStoredProcedureExecutor>();
        }
    }
}
