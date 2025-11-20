namespace TransactionSystems.Aggregator.Application.Models.Request.V1
{
    public sealed class GetTransactionByIdRequest
    {
        public Guid TransactionId { get; set; }
    }
}
