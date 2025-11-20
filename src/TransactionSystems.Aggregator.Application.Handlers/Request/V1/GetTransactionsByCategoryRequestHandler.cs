using Microsoft.Extensions.Logging;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Application.Models.Response.V1;
using TransactionSystems.Aggregator.Domain.Entities;
using TransactionSystems.Aggregator.Domain.Interfaces;
using TransactionSystems.Aggregator.Domain.Interfaces.Exceptions;
using TransactionSystems.Aggregator.Domain.Observability.Messages;
using TransactionSystems.Aggregator.Domain.UnitOfWork;

namespace TransactionSystems.Aggregator.Application.Handlers.Request.V1
{
    internal sealed class GetTransactionsByCategoryRequestHandler(
        ILogger<GetTransactionsByCategoryRequestHandler> logger,
        IUnitOfWorkFactory<ITransactionAggregatorUnitOfWork> unitOfWorkFactory)
        : IRequestHandler<GetTransactionsByCategoryRequest, Dictionary<string, List<TransactionResponse>>>
    {
        public async Task<Dictionary<string, List<TransactionResponse>>> HandleAsync(GetTransactionsByCategoryRequest request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(InfoMessages.MethodStarted);

            try
            {
                using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

                var transactions = await unitOfWork.TransactionRepository
                    .GetByCustomerIdAsync(request.CustomerId, cancellationToken);

                var grouped = transactions
                    .GroupBy(t => t.Category?.Name ?? "Uncategorized")
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(MapToTransactionResponse).ToList());

                return grouped;
            }
            catch (Exception ex)
            {
                throw new HandlerException(ErrorMessages.HandlerGenericErrorMessage, ex);
            }
        }

        private static TransactionResponse MapToTransactionResponse(Transaction transaction)
        {
            return new TransactionResponse
            {
                TransactionId = transaction.Id,
                CustomerId = transaction.CustomerId,
                DataSourceId = transaction.DataSourceId,
                DataSourceName = transaction.DataSource?.SourceName ?? string.Empty,
                CategoryId = transaction.CategoryId,
                CategoryName = transaction.Category?.Name ?? string.Empty,
                ExternalTransactionId = transaction.ExternalTransactionId,
                Description = transaction.Description,
                MerchantName = transaction.MerchantName,
                CurrencyCode = transaction.CurrencyCode,
                Amount = transaction.Amount,
                TransactionDate = transaction.TransactionDate,
                ProcessedDate = transaction.ProcessedDate,
                Type = transaction.Type,
                Status = transaction.Status,
                Tags = transaction.Tags.Select(t => $"{t.Key}: {t.Value}").ToList()
            };
        }
    }
}
