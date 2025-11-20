using System.Reflection;
using System.Text.Json.Serialization;

namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class ControllerRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddApplicationPart(Assembly.GetExecutingAssembly())
                .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
        }
    }
}
