using TransactionSystems.Aggregator.Domain.Repository;
using TransactionSystems.Aggregator.Domain.UnitOfWork;
using TransactionSystems.Aggregator.Infrastructure.Persistence.Context;

namespace TransactionSystems.Aggregator.Infrastructure.Persistence.UnitOfWork
{
    public sealed class TransactionAggregatorUnitOfWork : ITransactionAggregatorUnitOfWork, IDisposable
    {
        private readonly TransactionAggregatorDatabaseContext _context;
        private bool _disposed;

        public TransactionAggregatorUnitOfWork(TransactionAggregatorDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ITransactionRepository TransactionRepository => throw new NotImplementedException();
        public ICustomerRepository CustomerRepository => throw new NotImplementedException();
        public ITransactionCategoryRepository TransactionCategoryRepository => throw new NotImplementedException();
        public IDataSourceRepository DataSourceRepository => throw new NotImplementedException();
        public IPaymentMethodRepository PaymentMethodRepository => throw new NotImplementedException();
        public ICustomerDataSourceRepository CustomerDataSourceRepository => throw new NotImplementedException();
        public ITransactionReversalRepository TransactionReversalRepository => throw new NotImplementedException();

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Rollback()
        {
            // EF Core automatically tracks changes, so just don't call SaveChangesAsync
            // Alternatively, could reload entities from database if needed
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _context?.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
