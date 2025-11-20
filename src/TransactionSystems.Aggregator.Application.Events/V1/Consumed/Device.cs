namespace TransactionSystems.Aggregator.Domain.Interfaces.Events
{
    public sealed record Device
    {
        public required string Name { get; init; }
    }
}