namespace TransactionSystems.Aggregator.Domain.Models.Enumerations
{
    /// <summary>
    /// Specifies the type of payment method used for transactions.
    /// </summary>
    public enum PaymentMethodType
    {
        /// <summary>
        /// Credit card payment.
        /// </summary>
        CreditCard = 1,

        /// <summary>
        /// Debit card payment.
        /// </summary>
        DebitCard = 2,

        /// <summary>
        /// Direct bank account transfer or ACH.
        /// </summary>
        BankAccount = 3,

        /// <summary>
        /// Digital wallet (e.g., Apple Pay, Google Pay).
        /// </summary>
        DigitalWallet = 4,

        /// <summary>
        /// Cash payment.
        /// </summary>
        Cash = 5,

        /// <summary>
        /// Other or unspecified payment method.
        /// </summary>
        Other = 6
    }
}
