namespace TransactionSystems.Aggregator.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        void Rollback();
    }
}
