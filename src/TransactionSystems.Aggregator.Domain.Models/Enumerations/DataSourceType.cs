namespace TransactionSystems.Aggregator.Domain.Models.Enumerations
{
    /// <summary>
    /// Specifies the type of data source for transaction aggregation.
    /// </summary>
    public enum DataSourceType
    {
        /// <summary>
        /// Traditional bank account.
        /// </summary>
        Bank = 1,

        /// <summary>
        /// Credit card account.
        /// </summary>
        CreditCard = 2,

        /// <summary>
        /// Debit card account.
        /// </summary>
        DebitCard = 3,

        /// <summary>
        /// Digital payment application (e.g., PayPal, Venmo, Cash App).
        /// </summary>
        PaymentApp = 4,

        /// <summary>
        /// Retail store account or loyalty program.
        /// </summary>
        Store = 5,

        /// <summary>
        /// Cryptocurrency wallet or exchange.
        /// </summary>
        Cryptocurrency = 6,

        /// <summary>
        /// Other or unspecified data source type.
        /// </summary>
        Other = 7
    }
}
