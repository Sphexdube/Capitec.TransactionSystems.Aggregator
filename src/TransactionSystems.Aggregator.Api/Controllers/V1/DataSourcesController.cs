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
    public sealed class DataSourcesController(
        ILogger<DataSourcesController> logger,
        IRequestHandler<GetAllDataSourcesRequest, List<DataSourceResponse>> getAllDataSourcesHandler,
        IValidator<GetAllDataSourcesRequest> getAllDataSourcesValidator,
        IRequestHandler<GetConnectedDataSourcesRequest, List<DataSourceResponse>> getConnectedDataSourcesHandler,
        IValidator<GetConnectedDataSourcesRequest> getConnectedDataSourcesValidator) : BaseController(logger)
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<DataSourceResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDataSourcesAsync()
        {
            Logger.LogInformation(InfoMessages.MethodStarted);

            return await ProcessRequest(
                getAllDataSourcesValidator.ValidateAsync,
                getAllDataSourcesHandler.HandleAsync,
                new GetAllDataSourcesRequest());
        }

        [HttpGet("customer/{customerId}/connected")]
        [ProducesResponseType(typeof(List<DataSourceResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetConnectedDataSourcesAsync(Guid customerId)
        {
            Logger.LogInformation(InfoMessages.MethodStarted);

            return await ProcessRequest(
                getConnectedDataSourcesValidator.ValidateAsync,
                getConnectedDataSourcesHandler.HandleAsync,
                new GetConnectedDataSourcesRequest { CustomerId = customerId });
        }
    }
}
