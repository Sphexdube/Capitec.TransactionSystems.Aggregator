namespace TransactionSystems.Aggregator.Application.Models.Configuration
{
    /// <summary>
    /// Main configuration class for the Transaction Aggregator system.
    /// This configuration aggregates all application settings into a single cohesive configuration object.
    /// </summary>
    public sealed class TransactionAggregatorConfiguration
    {
        /// <summary>
        /// Gets or sets the API title for documentation.
        /// </summary>
        public string ApiTitle { get; set; } = "Capitec TransactionSystems Aggregator API";

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        public string ApiVersion { get; set; } = "v1";

        /// <summary>
        /// Gets or sets the environment name (Development, Test, Production).
        /// </summary>
        public string Environment { get; set; } = "Development";
    }
}
