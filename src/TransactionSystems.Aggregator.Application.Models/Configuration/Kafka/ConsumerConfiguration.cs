namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Kafka
{
    [Serializable]
    public sealed record ConsumerConfiguration
    {
        public required string GroupId { get; init; }

        public required string SslCaLocation { get; init; }

        public required string BootstrapServers { get; init; }

        public required TopicConfiguration TopicConfiguration { get; init; }

        public BatchConfiguration? BatchConfiguration { get; init; }

        public SaslConfiguration? SaslConfiguration { get; init; }

        public SchemaRegistryConfiguration? SchemaRegistry { get; init; }
    }
}
