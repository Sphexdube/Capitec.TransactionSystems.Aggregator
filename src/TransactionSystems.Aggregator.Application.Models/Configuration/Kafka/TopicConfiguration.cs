namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Kafka
{
    [Serializable]
    public sealed record TopicConfiguration
    {
        public required string Topic { get; init; }

        public required int KeySchemaType { get; init; }

        public required int ValueSchemaType { get; init; }
    }
}
