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
    internal sealed class GetCustomerTransactionsRequestHandler(
        ILogger<GetCustomerTransactionsRequestHandler> logger,
        IUnitOfWorkFactory<ITransactionAggregatorUnitOfWork> unitOfWorkFactory)
        : IRequestHandler<GetCustomerTransactionsRequest, List<TransactionResponse>>
    {
        public async Task<List<TransactionResponse>> HandleAsync(GetCustomerTransactionsRequest request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(InfoMessages.MethodStarted);

            try
            {
                using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

                List<Transaction> transactions;

                if (request.StartDate.HasValue && request.EndDate.HasValue)
                {
                    transactions = await unitOfWork.TransactionRepository
                        .GetByCustomerIdAndDateRangeAsync(
                            request.CustomerId,
                            request.StartDate.Value,
                            request.EndDate.Value,
                            cancellationToken);
                }
                else
                {
                    transactions = await unitOfWork.TransactionRepository
                        .GetByCustomerIdAsync(request.CustomerId, cancellationToken);
                }

                var responses = transactions.Select(MapToTransactionResponse).ToList();

                if (!string.IsNullOrWhiteSpace(request.Category))
                {
                    responses = responses.Where(t =>
                        t.CategoryName.Contains(request.Category, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                return responses;
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
