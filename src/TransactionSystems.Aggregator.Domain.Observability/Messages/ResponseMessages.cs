namespace TransactionSystems.Aggregator.Domain.Observability.Messages
{
    public static class ResponseMessages
    {
        public static readonly string RequestValidationFailure = "The request payload has failed validation. {0}";
        public static readonly string OrderIdInvalid = "A valid order Id must be provided.";
    }
}
