namespace TransactionSystems.Aggregator.Domain.UnitOfWork
{
    public interface IUnitOfWorkFactory<out TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        TUnitOfWork CreateUnitOfWork();
    }
}
