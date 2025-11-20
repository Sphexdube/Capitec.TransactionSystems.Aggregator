namespace TransactionSystems.Aggregator.Application.Models.Request.V1
{
    public sealed class GetTransactionsByCategoryRequest
    {
        public Guid CustomerId { get; set; }
    }
}
