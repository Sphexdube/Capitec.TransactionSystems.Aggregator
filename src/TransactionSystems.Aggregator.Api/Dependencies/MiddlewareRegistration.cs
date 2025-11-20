using TransactionSystems.Aggregator.Api.Middleware;

namespace TransactionSystems.Aggregator.Api.Dependencies
{
    public static class MiddlewareRegistration
    {
        public static void ConfigureMiddlewarePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TransactionSystems Aggregator API V1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Add custom exception handling middleware
            app.UseMiddleware<IntermediateExceptionHandler>();
        }
    }
}
