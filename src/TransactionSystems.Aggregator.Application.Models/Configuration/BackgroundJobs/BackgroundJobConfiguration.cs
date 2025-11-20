namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.BackgroundJobs
{
    [Serializable]
    public sealed class BackgroundJobConfiguration
    {
        public required string Name { get; init; }

        public required string Schedule { get; init; }
    }
}
