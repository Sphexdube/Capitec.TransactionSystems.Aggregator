namespace TransactionSystems.Aggregator.Domain.Models.Enumerations
{
    /// <summary>
    /// Specifies the current status of a transaction.
    /// </summary>
    public enum TransactionStatus
    {
        /// <summary>
        /// Transaction is pending and not yet finalized.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// Transaction has been posted to the account.
        /// </summary>
        Posted = 2,

        /// <summary>
        /// Transaction has been cleared and funds are settled.
        /// </summary>
        Cleared = 3,

        /// <summary>
        /// Transaction has been cancelled.
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// Transaction has failed.
        /// </summary>
        Failed = 5
    }
}
