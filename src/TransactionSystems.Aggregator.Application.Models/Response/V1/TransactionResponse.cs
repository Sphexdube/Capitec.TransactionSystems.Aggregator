using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Application.Models.Response.V1
{
    /// <summary>
    /// Response model representing a financial transaction.
    /// </summary>
    public sealed class TransactionResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the transaction.
        /// </summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the data source identifier.
        /// </summary>
        public Guid DataSourceId { get; set; }

        /// <summary>
        /// Gets or sets the data source name.
        /// </summary>
        public string DataSourceName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the payment method identifier.
        /// </summary>
        public Guid? PaymentMethodId { get; set; }

        /// <summary>
        /// Gets or sets the payment method name.
        /// </summary>
        public string? PaymentMethodName { get; set; }

        /// <summary>
        /// Gets or sets the external transaction identifier from the source system.
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
        /// Gets or sets the ISO 4217 currency code.
        /// </summary>
        public string CurrencyCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        public DateTimeOffset TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the processed date.
        /// </summary>
        public DateTimeOffset ProcessedDate { get; set; }

        /// <summary>
        /// Gets or sets the transaction type (Debit or Credit).
        /// </summary>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the transaction status.
        /// </summary>
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the collection of tags associated with the transaction.
        /// </summary>
        public List<string> Tags { get; set; } = [];
    }
}
