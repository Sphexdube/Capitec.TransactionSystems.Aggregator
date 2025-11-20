using TransactionSystems.Aggregator.Domain.Repository;

namespace TransactionSystems.Aggregator.Domain.UnitOfWork
{
    public interface ITransactionAggregatorUnitOfWork : IUnitOfWork
    {
        ITransactionRepository TransactionRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        ITransactionCategoryRepository TransactionCategoryRepository { get; }

        IDataSourceRepository DataSourceRepository { get; }

        IPaymentMethodRepository PaymentMethodRepository { get; }

        ICustomerDataSourceRepository CustomerDataSourceRepository { get; }

        ITransactionReversalRepository TransactionReversalRepository { get; }
    }
}
