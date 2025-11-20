namespace TransactionSystems.Aggregator.Domain.Interfaces.MasterData
{
    public sealed record CreatePaymentType
    {
        public required Guid Id { get; init; }

        public required string Description { get; init; }

        public required bool IsDeleted { get; init; }
    }
}
