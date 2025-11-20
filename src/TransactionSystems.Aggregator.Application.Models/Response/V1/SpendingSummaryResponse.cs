namespace TransactionSystems.Aggregator.Application.Models.Response.V1
{
    /// <summary>
    /// Response model representing a customer's spending summary.
    /// </summary>
    public sealed class SpendingSummaryResponse
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the summary period.
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the summary period.
        /// </summary>
        public DateTimeOffset EndDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount of all transactions.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total debit amount.
        /// </summary>
        public decimal TotalDebits { get; set; }

        /// <summary>
        /// Gets or sets the total credit amount.
        /// </summary>
        public decimal TotalCredits { get; set; }

        /// <summary>
        /// Gets or sets the number of transactions.
        /// </summary>
        public int TransactionCount { get; set; }

        /// <summary>
        /// Gets or sets the average transaction amount.
        /// </summary>
        public decimal AverageTransactionAmount { get; set; }

        /// <summary>
        /// Gets or sets the spending breakdown by category.
        /// </summary>
        public List<CategorySpendingResponse> SpendingByCategory { get; set; } = [];
    }

    /// <summary>
    /// Response model representing spending in a specific category.
    /// </summary>
    public sealed class CategorySpendingResponse
    {
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total amount spent in this category.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the number of transactions in this category.
        /// </summary>
        public int TransactionCount { get; set; }

        /// <summary>
        /// Gets or sets the percentage of total spending.
        /// </summary>
        public decimal Percentage { get; set; }
    }
}
