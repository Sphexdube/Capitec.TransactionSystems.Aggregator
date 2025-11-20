using TransactionSystems.Aggregator.Domain.Entities.Base;
using TransactionSystems.Aggregator.Domain.Models;
using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Domain.Entities
{
    /// <summary>
    /// Represents a financial transaction in the aggregation system.
    /// This is the core entity that replaces the Order entity.
    /// </summary>
    public sealed class Transaction : Aggregate<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        public Transaction()
            : base(Guid.Empty)
        {
            CustomerId = Guid.Empty;
            DataSourceId = Guid.Empty;
            CategoryId = Guid.Empty;
            PaymentMethodId = null;
            ExternalTransactionId = string.Empty;
            Description = string.Empty;
            MerchantName = string.Empty;
            CurrencyCode = string.Empty;
            Amount = 0m;
            TransactionDate = DateTimeOffset.MinValue;
            ProcessedDate = DateTimeOffset.UtcNow;
            Type = TransactionType.Debit;
            Status = TransactionStatus.Pending;
            Tags = [];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the transaction.</param>
        public Transaction(Guid id)
            : base(id)
        {
            CustomerId = Guid.Empty;
            DataSourceId = Guid.Empty;
            CategoryId = Guid.Empty;
            PaymentMethodId = null;
            ExternalTransactionId = string.Empty;
            Description = string.Empty;
            MerchantName = string.Empty;
            CurrencyCode = string.Empty;
            Amount = 0m;
            TransactionDate = DateTimeOffset.MinValue;
            ProcessedDate = DateTimeOffset.UtcNow;
            Type = TransactionType.Debit;
            Status = TransactionStatus.Pending;
            Tags = [];
        }

        /// <summary>
        /// Gets the identifier of the customer who owns this transaction.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the identifier of the data source from which this transaction originated.
        /// </summary>
        public Guid DataSourceId { get; private set; }

        /// <summary>
        /// Gets the identifier of the category this transaction belongs to.
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Gets the identifier of the payment method used for this transaction.
        /// </summary>
        public Guid? PaymentMethodId { get; private set; }

        /// <summary>
        /// Gets the external identifier from the source system.
        /// </summary>
        public string ExternalTransactionId { get; private set; }

        /// <summary>
        /// Gets the description of the transaction.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the name of the merchant or business.
        /// </summary>
        public string MerchantName { get; private set; }

        /// <summary>
        /// Gets the ISO 4217 currency code for this transaction.
        /// </summary>
        public string CurrencyCode { get; private set; }

        /// <summary>
        /// Gets the monetary amount of the transaction.
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Gets the date and time when the transaction occurred.
        /// </summary>
        public DateTimeOffset TransactionDate { get; private set; }

        /// <summary>
        /// Gets the date and time when the transaction was processed by the system.
        /// </summary>
        public DateTimeOffset ProcessedDate { get; private set; }

        /// <summary>
        /// Gets the type of transaction (Debit or Credit).
        /// </summary>
        public TransactionType Type { get; private set; }

        /// <summary>
        /// Gets the current status of the transaction.
        /// </summary>
        public TransactionStatus Status { get; private set; }

        /// <summary>
        /// Gets the collection of tags associated with this transaction.
        /// </summary>
        public List<TransactionTag> Tags { get; private set; }

        /// <summary>
        /// Gets the customer who owns this transaction.
        /// </summary>
        public Customer Customer { get; private set; } = null!;

        /// <summary>
        /// Gets the data source from which this transaction originated.
        /// </summary>
        public DataSource DataSource { get; private set; } = null!;

        /// <summary>
        /// Gets the category this transaction belongs to.
        /// </summary>
        public TransactionCategory Category { get; private set; } = null!;

        /// <summary>
        /// Gets the payment method used for this transaction.
        /// </summary>
        public PaymentMethod? PaymentMethod { get; private set; }
    }
}
