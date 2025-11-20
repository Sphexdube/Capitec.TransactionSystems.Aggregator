using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Application.Models.Response.V1
{
    /// <summary>
    /// Response model representing a transaction data source.
    /// </summary>
    public sealed class DataSourceResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the data source.
        /// </summary>
        public Guid DataSourceId { get; set; }

        /// <summary>
        /// Gets or sets the data source name.
        /// </summary>
        public string SourceName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of data source.
        /// </summary>
        public DataSourceType Type { get; set; }

        /// <summary>
        /// Gets or sets the data source description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the data source is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date when the data source was created.
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the last synchronization date.
        /// </summary>
        public DateTimeOffset? LastSyncDate { get; set; }

        /// <summary>
        /// Gets or sets the logo URL.
        /// </summary>
        public string LogoUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the customer is connected to this data source.
        /// </summary>
        public bool IsConnected { get; set; }
    }
}
