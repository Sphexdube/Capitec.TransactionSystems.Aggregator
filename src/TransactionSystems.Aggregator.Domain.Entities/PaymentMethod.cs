using TransactionSystems.Aggregator.Domain.Entities.Base;
using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Domain.Entities
{
    /// <summary>
    /// Represents a customer's payment instrument such as a credit card, debit card, or bank account.
    /// </summary>
    public sealed class PaymentMethod : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethod"/> class.
        /// </summary>
        public PaymentMethod()
            : base(Guid.Empty)
        {
            CustomerId = Guid.Empty;
            Name = string.Empty;
            Type = PaymentMethodType.Other;
            LastFourDigits = string.Empty;
            CardBrand = string.Empty;
            ExpiryDate = null;
            IsDefault = false;
            IsActive = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethod"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the payment method.</param>
        public PaymentMethod(Guid id)
            : base(id)
        {
            CustomerId = Guid.Empty;
            Name = string.Empty;
            Type = PaymentMethodType.Other;
            LastFourDigits = string.Empty;
            CardBrand = string.Empty;
            ExpiryDate = null;
            IsDefault = false;
            IsActive = true;
        }

        /// <summary>
        /// Gets the identifier of the customer who owns this payment method.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the user-friendly name for this payment method (e.g., "My Visa Card").
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type of payment method.
        /// </summary>
        public PaymentMethodType Type { get; private set; }

        /// <summary>
        /// Gets the last four digits of the card or account number for identification.
        /// </summary>
        public string LastFourDigits { get; private set; }

        /// <summary>
        /// Gets the card brand (e.g., "Visa", "Mastercard", "American Express").
        /// </summary>
        public string CardBrand { get; private set; }

        /// <summary>
        /// Gets the expiry date for cards.
        /// </summary>
        public DateTimeOffset? ExpiryDate { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this is the customer's default payment method.
        /// </summary>
        public bool IsDefault { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this payment method is currently active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Gets the customer who owns this payment method.
        /// </summary>
        public Customer Customer { get; private set; } = null!;
    }
}
