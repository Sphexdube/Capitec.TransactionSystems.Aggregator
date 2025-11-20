using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Infrastructure.DataSources.MockDataSources
{
    /// <summary>
    /// Interface for data source providers that simulate external financial institutions.
    /// </summary>
    public interface IDataSourceProvider
    {
        /// <summary>
        /// Gets the name of the data source provider.
        /// </summary>
        string SourceName { get; }

        /// <summary>
        /// Gets the type of data source (Bank, CreditCard, PaymentApp, etc.).
        /// </summary>
        DataSourceType SourceType { get; }

        /// <summary>
        /// Retrieves transactions for a specific customer within a date range.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <param name="startDate">The start date of the transaction period.</param>
        /// <param name="endDate">The end date of the transaction period.</param>
        /// <returns>A list of mock transactions.</returns>
        Task<List<MockTransaction>> GetTransactionsAsync(Guid customerId, DateTimeOffset startDate, DateTimeOffset endDate);

        /// <summary>
        /// Validates the connection to the data source for a specific customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>True if the connection is valid; otherwise, false.</returns>
        Task<bool> ValidateConnectionAsync(Guid customerId);
    }

    /// <summary>
    /// Represents a mock transaction from an external data source.
    /// </summary>
    public class MockTransaction
    {
        /// <summary>
        /// Gets or sets the external transaction identifier from the data source.
        /// </summary>
        public string ExternalTransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the transaction description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the merchant name.
        /// </summary>
        public string MerchantName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the transaction amount (negative for debits, positive for credits).
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the transaction date and time.
        /// </summary>
        public DateTimeOffset TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the transaction type ("Debit" or "Credit").
        /// </summary>
        public string TransactionType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the transaction category (e.g., Groceries, Dining, Transport).
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets additional metadata about the transaction.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
    }
}
