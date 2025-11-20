namespace TransactionSystems.Aggregator.Domain.Interfaces
{
    public interface IJob
    {
        Task DoJob();
    }
}
