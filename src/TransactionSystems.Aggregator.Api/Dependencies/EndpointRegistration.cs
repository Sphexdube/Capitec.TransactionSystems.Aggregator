namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class EndpointRegistration
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            // Map controllers
            app.MapControllers();

            // Map health check endpoints
            app.MapHealthChecks("/health");
            app.MapHealthChecks("/healthz");
        }
    }
}
