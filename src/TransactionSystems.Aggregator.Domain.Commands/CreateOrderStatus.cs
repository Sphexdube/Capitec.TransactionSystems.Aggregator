using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Domain.Interfaces
{
    public sealed record CreateOrderStatus
    {
        public required Guid OrderId { get; init; }

        public required OrderStatus Status { get; init; }
    }
}
