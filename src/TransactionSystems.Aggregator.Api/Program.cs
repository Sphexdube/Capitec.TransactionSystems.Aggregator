using TransactionSystems.Aggregator.Api.Dependencies;

namespace TransactionSystems.Aggregator.Api
{
    public class Program
    {
        protected Program()
        {
        }

        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationConfiguration(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddSwaggerDocumentation();
            builder.Services.AddHealthCheckServices();

            WebApplication app = builder.Build();

            app.ConfigureMiddlewarePipeline();
            app.ConfigureEndpoints();

            await app.RunAsync();
        }
    }
}
