using TransactionSystems.Aggregator.Domain.Entities;

namespace TransactionSystems.Aggregator.Domain.Repository
{
    /// <summary>
    /// Repository for managing Customer entities
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets a customer by ID
        /// </summary>
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a customer by email
        /// </summary>
        Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all customers
        /// </summary>
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new customer
        /// </summary>
        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        void Update(Customer customer);

        /// <summary>
        /// Deletes a customer
        /// </summary>
        void Delete(Customer customer);
    }
}
