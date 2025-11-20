namespace TransactionSystems.Aggregator.Domain.Models.Enumerations
{
    /// <summary>
    /// Specifies the type of transaction reversal.
    /// </summary>
    public enum ReversalType
    {
        /// <summary>
        /// A refund initiated by the merchant or customer.
        /// </summary>
        Refund = 1,

        /// <summary>
        /// A chargeback initiated by the card issuer or payment processor.
        /// </summary>
        Chargeback = 2,

        /// <summary>
        /// A cancellation of a pending transaction.
        /// </summary>
        Cancellation = 3,

        /// <summary>
        /// An adjustment or correction to a transaction amount.
        /// </summary>
        Adjustment = 4
    }
}
