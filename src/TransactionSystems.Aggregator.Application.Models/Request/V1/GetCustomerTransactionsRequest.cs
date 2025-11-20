namespace TransactionSystems.Aggregator.Application.Models.Request.V1
{
    public sealed class GetCustomerTransactionsRequest
    {
        public Guid CustomerId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? Category { get; set; }
    }
}
