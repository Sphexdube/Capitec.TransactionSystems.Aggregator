using TransactionSystems.Aggregator.Domain.Entities;

namespace TransactionSystems.Aggregator.Domain.Repository
{
    public interface ICustomerDataSourceRepository
    {
        Task<CustomerDataSource?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<CustomerDataSource>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);

        Task<List<CustomerDataSource>> GetByDataSourceIdAsync(Guid dataSourceId, CancellationToken cancellationToken = default);

        Task<CustomerDataSource?> GetByCustomerAndDataSourceAsync(
            Guid customerId,
            Guid dataSourceId,
            CancellationToken cancellationToken = default);

        Task AddAsync(CustomerDataSource customerDataSource, CancellationToken cancellationToken = default);

        void Update(CustomerDataSource customerDataSource);

        void Delete(CustomerDataSource customerDataSource);
    }
}
