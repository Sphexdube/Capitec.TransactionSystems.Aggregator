namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Kafka
{
    [Serializable]
    public sealed record SaslConfiguration
    {
        public required string Username { get; init; }

        public required string Password { get; init; }
    }
}
