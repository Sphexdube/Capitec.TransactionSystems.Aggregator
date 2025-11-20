using TransactionSystems.Aggregator.Domain.Entities;

namespace TransactionSystems.Aggregator.Domain.Repository
{
    /// <summary>
    /// Repository for managing TransactionCategory entities
    /// </summary>
    public interface ITransactionCategoryRepository
    {
        /// <summary>
        /// Gets a category by ID
        /// </summary>
        Task<TransactionCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a category by name
        /// </summary>
        Task<TransactionCategory?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all categories
        /// </summary>
        Task<List<TransactionCategory>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all top-level categories (no parent)
        /// </summary>
        Task<List<TransactionCategory>> GetTopLevelCategoriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets subcategories for a parent category
        /// </summary>
        Task<List<TransactionCategory>> GetSubCategoriesAsync(Guid parentCategoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new category
        /// </summary>
        Task AddAsync(TransactionCategory category, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing category
        /// </summary>
        void Update(TransactionCategory category);

        /// <summary>
        /// Deletes a category
        /// </summary>
        void Delete(TransactionCategory category);
    }
}
