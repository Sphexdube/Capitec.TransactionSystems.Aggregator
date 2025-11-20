using TransactionSystems.Aggregator.Domain.Entities;

namespace TransactionSystems.Aggregator.Domain.Repository
{
    public interface IDataSourceRepository
    {
        Task<DataSource?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<DataSource>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        Task<List<DataSource>> GetAllAsync(CancellationToken cancellationToken = default);

        Task AddAsync(DataSource dataSource, CancellationToken cancellationToken = default);

        void Update(DataSource dataSource);

        void Delete(DataSource dataSource);
    }
}
