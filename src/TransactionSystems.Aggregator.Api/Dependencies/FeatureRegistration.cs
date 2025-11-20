namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class FeatureRegistration
    {
        public static void Register(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Background jobs and advanced features disabled for MVP
            // Can be re-enabled when Hangfire dependencies are restored
        }
    }
}
