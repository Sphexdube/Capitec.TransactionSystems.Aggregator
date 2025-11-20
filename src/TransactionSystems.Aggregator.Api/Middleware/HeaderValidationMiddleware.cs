using Microsoft.AspNetCore.Http;

namespace TransactionSystems.Aggregator.Api.Middleware
{
    public class HeaderValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HashSet<string> _ignorePaths;

        public HeaderValidationMiddleware(RequestDelegate next)
        {
            _next = next;
            _ignorePaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "/ui",
                "/backgroundjobs",
                "/healthchecks-api",
                "/healthchecks-ui",
                "/health",
                "/healthz",
                "/metrics",
                "/swagger",
                "/api"
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value ?? string.Empty;

            // Skip validation for ignored paths
            if (_ignorePaths.Any(ignorePath => path.StartsWith(ignorePath, StringComparison.OrdinalIgnoreCase)))
            {
                await _next(context);
                return;
            }

            await _next(context);
        }
    }
}
