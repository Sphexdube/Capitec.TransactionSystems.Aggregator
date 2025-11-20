namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Kafka
{
    public sealed record BatchConfiguration
    {
        public required int Size { get; init; }
    }
}
