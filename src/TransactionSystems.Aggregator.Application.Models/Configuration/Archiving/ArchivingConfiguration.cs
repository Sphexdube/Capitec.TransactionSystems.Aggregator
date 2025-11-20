namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Archiving
{
    [Serializable]
    public sealed class ArchivingConfiguration
    {
        public required string ArchiveStoredProcedure { get; init; }

        public required string CleanupStoredProcedure { get; init; }
    }
}