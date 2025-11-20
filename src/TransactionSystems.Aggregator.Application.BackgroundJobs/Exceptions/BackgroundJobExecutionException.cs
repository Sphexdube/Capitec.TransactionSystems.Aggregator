namespace TransactionSystems.Aggregator.Application.BackgroundJobs.Exceptions
{
    public sealed class BackgroundJobExecutionException : Exception
    {
        public BackgroundJobExecutionException()
        {
        }

        public BackgroundJobExecutionException(string message)
            : base(message)
        {
        }

        public BackgroundJobExecutionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
