using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TransactionSystems.Aggregator.Api.Controllers.Base
{
    public abstract class BaseController(ILogger logger) : ControllerBase
    {
        protected ILogger Logger { get; } = logger;

        protected async Task<IActionResult> ProcessRequest<TRequest, TResponse>(
            Func<TRequest, CancellationToken, Task<ValidationResult>> validateAsync,
            Func<TRequest, CancellationToken, Task<TResponse>> handleAsync,
            TRequest request)
        {
            var validationResult = await validateAsync(request, HttpContext.RequestAborted);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var response = await handleAsync(request, HttpContext.RequestAborted);
            return Ok(response);
        }
    }
}
