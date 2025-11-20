namespace TransactionSystems.Aggregator.Domain.Models
{
    /// <summary>
    /// Represents a connection between a customer and a data source.
    /// This value object tracks the connection status and synchronization information.
    /// </summary>
    public sealed class DataSourceConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceConnection"/> class.
        /// </summary>
        public DataSourceConnection()
        {
            DataSourceId = Guid.Empty;
            AccountNumber = string.Empty;
            IsConnected = false;
            ConnectedDate = DateTimeOffset.UtcNow;
            LastSyncDate = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceConnection"/> class with the specified values.
        /// </summary>
        /// <param name="dataSourceId">The identifier of the data source.</param>
        /// <param name="accountNumber">The account number or identifier at the data source.</param>
        /// <param name="isConnected">Indicates whether the connection is currently active.</param>
        /// <param name="connectedDate">The date when the connection was established.</param>
        /// <param name="lastSyncDate">The date of the last successful synchronization.</param>
        public DataSourceConnection(
            Guid dataSourceId,
            string accountNumber,
            bool isConnected,
            DateTimeOffset connectedDate,
            DateTimeOffset? lastSyncDate)
        {
            DataSourceId = dataSourceId;
            AccountNumber = accountNumber ?? string.Empty;
            IsConnected = isConnected;
            ConnectedDate = connectedDate;
            LastSyncDate = lastSyncDate;
        }

        /// <summary>
        /// Gets the identifier of the data source being connected to.
        /// </summary>
        public Guid DataSourceId { get; private set; }

        /// <summary>
        /// Gets the account number or identifier at the data source (may be masked or encrypted).
        /// </summary>
        public string AccountNumber { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the connection is currently active and operational.
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// Gets the date and time when the connection was initially established.
        /// </summary>
        public DateTimeOffset ConnectedDate { get; private set; }

        /// <summary>
        /// Gets the date and time of the last successful data synchronization from this source.
        /// </summary>
        public DateTimeOffset? LastSyncDate { get; private set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DataSourceConnection other)
            {
                return false;
            }

            return DataSourceId == other.DataSourceId &&
                   AccountNumber == other.AccountNumber &&
                   IsConnected == other.IsConnected &&
                   ConnectedDate == other.ConnectedDate &&
                   LastSyncDate == other.LastSyncDate;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(DataSourceId, AccountNumber, IsConnected, ConnectedDate, LastSyncDate);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var status = IsConnected ? "Connected" : "Disconnected";
            return $"DataSource {DataSourceId} - Account {AccountNumber} ({status})";
        }
    }
}
