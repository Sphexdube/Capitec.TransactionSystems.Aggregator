using TransactionSystems.Aggregator.Domain.Entities.Base;
using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Domain.Entities
{
    /// <summary>
    /// Represents a reversal of a transaction, such as a refund, chargeback, cancellation, or adjustment.
    /// Links the original transaction to its reversal transaction.
    /// </summary>
    public sealed class TransactionReversal : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionReversal"/> class.
        /// </summary>
        public TransactionReversal()
            : base(Guid.Empty)
        {
            OriginalTransactionId = Guid.Empty;
            ReversalTransactionId = Guid.Empty;
            Type = ReversalType.Refund;
            Reason = string.Empty;
            Amount = 0m;
            ReversalDate = DateTimeOffset.UtcNow;
            Status = ReversalStatus.Pending;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionReversal"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the transaction reversal.</param>
        public TransactionReversal(Guid id)
            : base(id)
        {
            OriginalTransactionId = Guid.Empty;
            ReversalTransactionId = Guid.Empty;
            Type = ReversalType.Refund;
            Reason = string.Empty;
            Amount = 0m;
            ReversalDate = DateTimeOffset.UtcNow;
            Status = ReversalStatus.Pending;
        }

        /// <summary>
        /// Gets the identifier of the original transaction being reversed.
        /// </summary>
        public Guid OriginalTransactionId { get; private set; }

        /// <summary>
        /// Gets the identifier of the reversal transaction.
        /// </summary>
        public Guid ReversalTransactionId { get; private set; }

        /// <summary>
        /// Gets the type of reversal (e.g., Refund, Chargeback, Cancellation).
        /// </summary>
        public ReversalType Type { get; private set; }

        /// <summary>
        /// Gets the reason for the reversal.
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        /// Gets the amount being reversed. May be partial or full amount of original transaction.
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Gets the date and time when the reversal was initiated.
        /// </summary>
        public DateTimeOffset ReversalDate { get; private set; }

        /// <summary>
        /// Gets the current status of the reversal.
        /// </summary>
        public ReversalStatus Status { get; private set; }

        /// <summary>
        /// Gets the original transaction that is being reversed.
        /// </summary>
        public Transaction OriginalTransaction { get; private set; } = null!;

        /// <summary>
        /// Gets the reversal transaction record.
        /// </summary>
        public Transaction ReversalTransaction { get; private set; } = null!;
    }
}
