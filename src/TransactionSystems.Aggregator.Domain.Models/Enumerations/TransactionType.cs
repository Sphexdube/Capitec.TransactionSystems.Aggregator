namespace TransactionSystems.Aggregator.Domain.Models.Enumerations
{
    /// <summary>
    /// Specifies the type of transaction.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Represents a debit transaction (money going out).
        /// </summary>
        Debit = 1,

        /// <summary>
        /// Represents a credit transaction (money coming in).
        /// </summary>
        Credit = 2
    }
}
