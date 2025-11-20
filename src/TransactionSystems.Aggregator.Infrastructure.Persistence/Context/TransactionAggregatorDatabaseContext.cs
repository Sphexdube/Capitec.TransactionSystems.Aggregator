using Microsoft.EntityFrameworkCore;
using TransactionSystems.Aggregator.Domain.Entities;

namespace TransactionSystems.Aggregator.Infrastructure.Persistence.Context
{
    public sealed class TransactionAggregatorDatabaseContext : DbContext
    {
        public TransactionAggregatorDatabaseContext(DbContextOptions<TransactionAggregatorDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<DataSource> DataSources => Set<DataSource>();
        public DbSet<TransactionCategory> TransactionCategories => Set<TransactionCategory>();
        public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
        public DbSet<CustomerDataSource> CustomerDataSources => Set<CustomerDataSource>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<TransactionReversal> TransactionReversals => Set<TransactionReversal>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations from mappings
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransactionAggregatorDatabaseContext).Assembly);
        }
    }
}
