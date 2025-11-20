using TransactionSystems.Aggregator.Domain.Entities;

namespace TransactionSystems.Aggregator.Domain.Repository
{
    public interface ITransactionReversalRepository
    {
        Task<TransactionReversal?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<TransactionReversal?> GetByOriginalTransactionIdAsync(Guid originalTransactionId, CancellationToken cancellationToken = default);

        Task<List<TransactionReversal>> GetByReversalTransactionIdAsync(Guid reversalTransactionId, CancellationToken cancellationToken = default);

        Task<List<TransactionReversal>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);

        Task AddAsync(TransactionReversal transactionReversal, CancellationToken cancellationToken = default);

        void Update(TransactionReversal transactionReversal);

        void Delete(TransactionReversal transactionReversal);
    }
}
