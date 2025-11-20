using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Domain.Interfaces
{
    public sealed record UpdateOrderStatus
    {
        public required OrderStatus Status { get; init; }
    }
}
