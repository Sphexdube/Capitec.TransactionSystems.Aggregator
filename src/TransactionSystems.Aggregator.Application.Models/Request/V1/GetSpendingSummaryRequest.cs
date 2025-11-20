namespace TransactionSystems.Aggregator.Application.Models.Request.V1
{
    public sealed class GetSpendingSummaryRequest
    {
        public Guid CustomerId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
