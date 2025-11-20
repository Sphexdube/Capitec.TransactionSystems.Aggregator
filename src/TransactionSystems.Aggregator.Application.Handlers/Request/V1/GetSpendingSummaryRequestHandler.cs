using Microsoft.Extensions.Logging;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Application.Models.Response.V1;
using TransactionSystems.Aggregator.Domain.Entities;
using TransactionSystems.Aggregator.Domain.Interfaces;
using TransactionSystems.Aggregator.Domain.Interfaces.Exceptions;
using TransactionSystems.Aggregator.Domain.Models.Enumerations;
using TransactionSystems.Aggregator.Domain.Observability.Messages;
using TransactionSystems.Aggregator.Domain.UnitOfWork;

namespace TransactionSystems.Aggregator.Application.Handlers.Request.V1
{
    internal sealed class GetSpendingSummaryRequestHandler(
        ILogger<GetSpendingSummaryRequestHandler> logger,
        IUnitOfWorkFactory<ITransactionAggregatorUnitOfWork> unitOfWorkFactory)
        : IRequestHandler<GetSpendingSummaryRequest, SpendingSummaryResponse>
    {
        public async Task<SpendingSummaryResponse> HandleAsync(GetSpendingSummaryRequest request, CancellationToken cancellationToken = default)
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

                var debitTransactions = transactions.Where(t => t.Type == TransactionType.Debit).ToList();
                var creditTransactions = transactions.Where(t => t.Type == TransactionType.Credit).ToList();

                var totalDebits = debitTransactions.Sum(t => Math.Abs(t.Amount));
                var totalCredits = creditTransactions.Sum(t => Math.Abs(t.Amount));

                var spendingByCategory = debitTransactions
                    .GroupBy(t => new { CategoryId = t.Category?.Id ?? Guid.Empty, CategoryName = t.Category?.Name ?? "Uncategorized" })
                    .Select(g => new CategorySpendingResponse
                    {
                        CategoryId = g.Key.CategoryId,
                        CategoryName = g.Key.CategoryName,
                        Amount = g.Sum(t => Math.Abs(t.Amount)),
                        TransactionCount = g.Count(),
                        Percentage = totalDebits > 0 ? (g.Sum(t => Math.Abs(t.Amount)) / totalDebits) * 100 : 0
                    })
                    .ToList();

                return new SpendingSummaryResponse
                {
                    CustomerId = request.CustomerId,
                    TotalDebits = totalDebits,
                    TotalCredits = totalCredits,
                    TotalAmount = totalDebits + totalCredits,
                    TransactionCount = debitTransactions.Count,
                    AverageTransactionAmount = debitTransactions.Count > 0 ? totalDebits / debitTransactions.Count : 0,
                    SpendingByCategory = spendingByCategory,
                    StartDate = request.StartDate ?? (transactions.Any() ? transactions.Min(t => t.TransactionDate) : DateTimeOffset.UtcNow),
                    EndDate = request.EndDate ?? (transactions.Any() ? transactions.Max(t => t.TransactionDate) : DateTimeOffset.UtcNow)
                };
            }
            catch (Exception ex)
            {
                throw new HandlerException(ErrorMessages.HandlerGenericErrorMessage, ex);
            }
        }
    }
}
