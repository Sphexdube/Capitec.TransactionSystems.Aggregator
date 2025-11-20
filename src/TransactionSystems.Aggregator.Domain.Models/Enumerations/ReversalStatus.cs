namespace TransactionSystems.Aggregator.Domain.Models.Enumerations
{
    /// <summary>
    /// Specifies the current status of a transaction reversal.
    /// </summary>
    public enum ReversalStatus
    {
        /// <summary>
        /// Reversal has been initiated but not yet processed.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// Reversal has been approved and is being processed.
        /// </summary>
        Approved = 2,

        /// <summary>
        /// Reversal has been completed and funds have been returned.
        /// </summary>
        Completed = 3,

        /// <summary>
        /// Reversal has been rejected and will not be processed.
        /// </summary>
        Rejected = 4
    }
}
