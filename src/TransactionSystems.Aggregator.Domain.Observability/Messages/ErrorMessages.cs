
namespace TransactionSystems.Aggregator.Domain.Observability.Messages
{
    public static class ErrorMessages
    {
        public const string BackgroundjobGeneralErrorMessage = "Something went wrong while trying to execute the backgound job.";
        public const string BackgroundjobStoredProcedureFailedToExecuteErrorMessage = "The stored procedure {0}, indicated a failure result.";
        public const string HashiCorpVaultHealthCheckErrorMessage = "Something went wrong with the hashicorp vault health check.";
        public const string StoredProcedureFailedToExecuteErrorMessage = "Something went wrong while trying to execute the {0} stored procedure.";
        public const string KafkaConsumerConfigurationMissingErrorMessage = "The configuration for the {0} consumer is missing.";
        public const string SaveContextErrorMessage = "An error occurred while saving the database context.";
        public const string HandlerGenericErrorMessage = "An error occurred while processing the request in the handler.";
        public const string OutboxMessageDeserializationErrorMessage = "Something went wrong while trying to deserialize the outbox message.";
        public const string KafkaDeliveryObserverErrorMessage = "Something went wrong while trying to observe the delivery message.";
        public const string DictionaryKeyNotFoundErrorMessage = "The required key, {0}, was not found in the dictionary.";
        public const string ProcessingError = "Something went went wrong while trying to process {0} messages.";
        public const string TransactionNotFoundErrorMessage = "The required transaction details for transaction Id {0}, were not found.";
    }
}
