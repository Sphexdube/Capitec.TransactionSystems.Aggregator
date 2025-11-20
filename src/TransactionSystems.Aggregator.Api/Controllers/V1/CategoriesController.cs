using Asp.Versioning;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransactionSystems.Aggregator.Api.Controllers.Base;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Application.Models.Response.V1;
using TransactionSystems.Aggregator.Domain.Interfaces;
using TransactionSystems.Aggregator.Domain.Observability.Messages;

namespace TransactionSystems.Aggregator.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class CategoriesController(
        ILogger<CategoriesController> logger,
        IRequestHandler<GetAllCategoriesRequest, List<CategoryResponse>> getAllCategoriesHandler,
        IValidator<GetAllCategoriesRequest> getAllCategoriesValidator,
        IRequestHandler<GetCategoryByIdRequest, CategoryResponse> getCategoryByIdHandler,
        IValidator<GetCategoryByIdRequest> getCategoryByIdValidator) : BaseController(logger)
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            Logger.LogInformation(InfoMessages.MethodStarted);

            return await ProcessRequest(
                getAllCategoriesValidator.ValidateAsync,
                getAllCategoriesHandler.HandleAsync,
                new GetAllCategoriesRequest());
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(typeof(CategoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCategoryAsync(Guid categoryId)
        {
            Logger.LogInformation(InfoMessages.MethodStarted);

            return await ProcessRequest(
                getCategoryByIdValidator.ValidateAsync,
                getCategoryByIdHandler.HandleAsync,
                new GetCategoryByIdRequest { CategoryId = categoryId });
        }
    }
}
