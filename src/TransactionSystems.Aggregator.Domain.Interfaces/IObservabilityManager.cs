namespace TransactionSystems.Aggregator.Domain.Interfaces
{
    public interface IObservabilityManager
    {
        IObservabilityManager LogMessage(string message);

        void AsInfo();

        void AsError(Exception exception);
    }
}
