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
    public sealed class TransactionsController(
        ILogger<TransactionsController> logger,
        IRequestHandler<GetCustomerTransactionsRequest, List<TransactionResponse>> getCustomerTransactionsHandler,
        IValidator<GetCustomerTransactionsRequest> getCustomerTransactionsValidator,
        IRequestHandler<GetTransactionByIdRequest, TransactionResponse> getTransactionByIdHandler,
        IValidator<GetTransactionByIdRequest> getTransactionByIdValidator,
        IRequestHandler<GetTransactionsByCategoryRequest, Dictionary<string, List<TransactionResponse>>> getTransactionsByCategoryHandler,
        IValidator<GetTransactionsByCategoryRequest> getTransactionsByCategoryValidator,
        IRequestHandler<GetSpendingSummaryRequest, SpendingSummaryResponse> getSpendingSummaryHandler,
        IValidator<GetSpendingSummaryRequest> getSpendingSummaryValidator) : BaseController(logger)
    {
        [HttpGet("customer/{customerId}")]
        [ProducesResponseType(typeof(List<TransactionResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCustomerTransactionsAsync(
            Guid customerId,
            [FromQuery] DateTimeOffset? startDate = null,
            [FromQuery] DateTimeOffset? endDate = null,
            [FromQuery] string? category = null)
        {
            Logger.LogInformation(InfoMessages.MethodStarted);

            return await ProcessRequest(
                getCustomerTransactionsValidator.ValidateAsync,
                getCustomerTransactionsHandler.HandleAsync,
                new GetCustomerTransactionsRequest
                {
                    CustomerId = customerId,
                    StartDate = startDate,
                    EndDate = endDate,
                    Category = category
                });
        }

        [HttpGet("{transactionId}")]
        [ProducesResponseType(typeof(TransactionResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTransactionAsync(Guid transactionId)
        {
            Logger.LogInformation(InfoMessages.MethodStarted);

            return await ProcessRequest(
                getTransactionByIdValidator.ValidateAsync,
                getTransactionByIdHandler.HandleAsync,
                new GetTransactionByIdRequest { TransactionId = transactionId });
        }

        [HttpGet("customer/{customerId}/by-category")]
        [ProducesResponseType(typeof(Dictionary<string, List<TransactionResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTransactionsByCategoryAsync(Guid customerId)
        {
            Logger.LogInformation(InfoMessages.MethodStarted);

            return await ProcessRequest(
                getTransactionsByCategoryValidator.ValidateAsync,
                getTransactionsByCategoryHandler.HandleAsync,
                new GetTransactionsByCategoryRequest { CustomerId = customerId });
        }

        [HttpGet("customer/{customerId}/summary")]
        [ProducesResponseType(typeof(SpendingSummaryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSpendingSummaryAsync(
            Guid customerId,
            [FromQuery] DateTimeOffset? startDate = null,
            [FromQuery] DateTimeOffset? endDate = null)
        {
            Logger.LogInformation(InfoMessages.MethodStarted);

            return await ProcessRequest(
                getSpendingSummaryValidator.ValidateAsync,
                getSpendingSummaryHandler.HandleAsync,
                new GetSpendingSummaryRequest
                {
                    CustomerId = customerId,
                    StartDate = startDate,
                    EndDate = endDate
                });
        }
    }
}
