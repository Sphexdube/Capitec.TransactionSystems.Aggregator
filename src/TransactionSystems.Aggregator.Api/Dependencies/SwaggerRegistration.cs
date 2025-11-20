using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class SwaggerRegistration
    {
        public static void Register(SwaggerGenOptions options)
        {
            List<string> xmlFiles = [
                $"{Assembly.GetExecutingAssembly().GetName().Name}.xml",
                "TransactionSystems.Aggregator.Application.Models.xml"
            ];

            foreach (string xmlFile in xmlFiles)
            {
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath);
                }
            }
        }
    }
}
