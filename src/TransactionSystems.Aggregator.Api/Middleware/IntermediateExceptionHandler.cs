using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace TransactionSystems.Aggregator.Api.Middleware
{
    public class IntermediateExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<IntermediateExceptionHandler> _logger;

        public IntermediateExceptionHandler(RequestDelegate next, ILogger<IntermediateExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                ArgumentException or ArgumentNullException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                error = exception.Message,
                statusCode = context.Response.StatusCode,
                timestamp = DateTimeOffset.UtcNow
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
