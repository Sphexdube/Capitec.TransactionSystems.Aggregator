using TransactionSystems.Aggregator.Domain.Entities;

namespace TransactionSystems.Aggregator.Domain.Repository
{
    /// <summary>
    /// Repository for managing Transaction entities
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// Gets a transaction by ID
        /// </summary>
        Task<Transaction?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all transactions for a customer
        /// </summary>
        Task<List<Transaction>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets transactions for a customer within a date range
        /// </summary>
        Task<List<Transaction>> GetByCustomerIdAndDateRangeAsync(
            Guid customerId,
            DateTimeOffset startDate,
            DateTimeOffset endDate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets transactions by category
        /// </summary>
        Task<List<Transaction>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets transactions by data source
        /// </summary>
        Task<List<Transaction>> GetByDataSourceIdAsync(Guid dataSourceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new transaction
        /// </summary>
        Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing transaction
        /// </summary>
        void Update(Transaction transaction);

        /// <summary>
        /// Deletes a transaction
        /// </summary>
        void Delete(Transaction transaction);
    }
}
