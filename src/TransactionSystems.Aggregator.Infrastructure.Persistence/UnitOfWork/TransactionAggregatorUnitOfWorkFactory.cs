using Microsoft.EntityFrameworkCore;
using TransactionSystems.Aggregator.Domain.UnitOfWork;
using TransactionSystems.Aggregator.Infrastructure.Persistence.Context;

namespace TransactionSystems.Aggregator.Infrastructure.Persistence.UnitOfWork
{
    public sealed class TransactionAggregatorUnitOfWorkFactory : IUnitOfWorkFactory<ITransactionAggregatorUnitOfWork>
    {
        private readonly IDbContextFactory<TransactionAggregatorDatabaseContext> _contextFactory;

        public TransactionAggregatorUnitOfWorkFactory(IDbContextFactory<TransactionAggregatorDatabaseContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public ITransactionAggregatorUnitOfWork CreateUnitOfWork()
        {
            TransactionAggregatorDatabaseContext context = _contextFactory.CreateDbContext();
            return new TransactionAggregatorUnitOfWork(context);
        }
    }
}
