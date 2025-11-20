using TransactionSystems.Aggregator.Domain.Entities.Base;
using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Domain.Entities
{
    /// <summary>
    /// Represents an external data source such as a bank, credit card company, or payment application.
    /// Data sources provide transaction data that is aggregated into the system.
    /// </summary>
    public sealed class DataSource : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSource"/> class.
        /// </summary>
        public DataSource()
            : base(Guid.Empty)
        {
            SourceName = string.Empty;
            Type = DataSourceType.Other;
            Description = string.Empty;
            IsActive = true;
            CreatedDate = DateTimeOffset.UtcNow;
            LastSyncDate = null;
            LogoUrl = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSource"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the data source.</param>
        public DataSource(Guid id)
            : base(id)
        {
            SourceName = string.Empty;
            Type = DataSourceType.Other;
            Description = string.Empty;
            IsActive = true;
            CreatedDate = DateTimeOffset.UtcNow;
            LastSyncDate = null;
            LogoUrl = string.Empty;
        }

        /// <summary>
        /// Gets the name of the data source (e.g., "Chase Bank", "PayPal").
        /// </summary>
        public string SourceName { get; private set; }

        /// <summary>
        /// Gets the type of data source.
        /// </summary>
        public DataSourceType Type { get; private set; }

        /// <summary>
        /// Gets the description of the data source.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the data source is currently active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Gets the date and time when the data source was added to the system.
        /// </summary>
        public DateTimeOffset CreatedDate { get; private set; }

        /// <summary>
        /// Gets the date and time of the last successful synchronization with this data source.
        /// </summary>
        public DateTimeOffset? LastSyncDate { get; private set; }

        /// <summary>
        /// Gets the URL to the logo or icon representing this data source.
        /// </summary>
        public string LogoUrl { get; private set; }
    }
}
