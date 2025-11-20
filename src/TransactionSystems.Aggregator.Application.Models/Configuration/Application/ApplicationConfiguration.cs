using TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Archiving;
using TransactionSystems.Aggregator.Domain.Interfaces.Configuration.BackgroundJobs;
using TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Kafka;
using TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Persistence;
using TransactionSystems.Aggregator.Domain.Interfaces.Configuration.TokenSecurity;

namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Application
{
    [Serializable]
    public sealed class ApplicationConfiguration
    {
        public required TokenSecurityConfiguration TokenSecurity { get; init; }

        public required Dictionary<string, SqlServerConfiguration> Persistence { get; init; }

        public required ArchivingConfiguration Archiving { get; init; }

        public required Dictionary<string, BackgroundJobConfiguration> BackgroundJobs { get; init; }

        public required Dictionary<string, ConsumerConfiguration> KafkaConsumers { get; init; }
    }
}
