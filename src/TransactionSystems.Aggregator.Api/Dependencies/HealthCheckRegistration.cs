namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class HealthCheckRegistration
    {
        public static void Register(IHealthChecksBuilder healthChecksBuilder)
        {
            // Basic health checks are already registered in ServiceCollectionExtensions
            // No additional configuration needed for MVP
        }
    }
}
