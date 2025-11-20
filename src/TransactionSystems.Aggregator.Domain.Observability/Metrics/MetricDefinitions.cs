namespace TransactionSystems.Aggregator.Domain.Observability.Metrics
{
    public static class MetricDefinitions
    {
        // Metric names for future standard .NET Metrics implementation
        public const string HealthCheckSuccessCountName = "healthcheck.success.count";
        public const string HealthCheckErrorCountName = "healthcheck.error.count";
        public const string OrderNewCountName = "order.new.count";
        public const string OrderUpdateCountName = "order.update.count";
        public const string OrderStatusNewCountName = "order.status.new.count";
        public const string OrderStatusUpdateCountName = "order.status.update.count";
        public const string PaymentNewCountName = "payment.new.count";
        public const string PaymentUpdateCountName = "payment.update.count";
        public const string GroupNewCountName = "payment.group.new.count";
        public const string GroupUpdateCountName = "payment.group.update.count";
        public const string TransactionNewCountName = "transaction.new.count";
        public const string TransactionUpdateCountName = "transaction.update.count";
        public const string TransactionReversalNewCountName = "transaction.reversal.new.count";
        public const string TransactionReversalUpdateCountName = "transaction.reversal.update.count";
        public const string TransactionCategoryNewCountName = "transaction.category.new.count";
        public const string TransactionCategoryUpdateCountName = "transaction.category.update.count";
        public const string GetTransactionsByCustomerIdRequestSuccessCountName = "get.transactions.by.customerid.success.count";
        public const string GetTransactionsByCustomerIdRequestFailedCountName = "get.transactions.by.customerid.failure.count";
    }
}
