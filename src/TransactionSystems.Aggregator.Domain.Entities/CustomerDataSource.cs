using TransactionSystems.Aggregator.Domain.Entities.Base;

namespace TransactionSystems.Aggregator.Domain.Entities
{
    public sealed class CustomerDataSource : Entity<Guid>
    {
        public CustomerDataSource()
            : base(Guid.Empty)
        {
            CustomerId = Guid.Empty;
            DataSourceId = Guid.Empty;
            AccountNumber = string.Empty;
            AccountName = string.Empty;
            IsConnected = false;
            ConnectedDate = DateTimeOffset.UtcNow;
            LastSyncDate = null;
        }

        public CustomerDataSource(Guid id)
            : base(id)
        {
            CustomerId = Guid.Empty;
            DataSourceId = Guid.Empty;
            AccountNumber = string.Empty;
            AccountName = string.Empty;
            IsConnected = false;
            ConnectedDate = DateTimeOffset.UtcNow;
            LastSyncDate = null;
        }

        public Guid CustomerId { get; private set; }

        public Guid DataSourceId { get; private set; }

        public string AccountNumber { get; private set; }

        public string AccountName { get; private set; }

        public bool IsConnected { get; private set; }

        public DateTimeOffset ConnectedDate { get; private set; }

        public DateTimeOffset? LastSyncDate { get; private set; }

        public Customer Customer { get; private set; } = null!;

        public DataSource DataSource { get; private set; } = null!;
    }
}
