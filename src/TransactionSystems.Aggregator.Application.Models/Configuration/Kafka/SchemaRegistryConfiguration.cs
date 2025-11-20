namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Kafka
{
    [Serializable]
    public sealed record SchemaRegistryConfiguration
    {
        public required string Url { get; init; }

        public required bool EnableSslVerification { get; init; }

        public required string Username { get; init; }

        public required string Password { get; init; }
    }
}
