using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Infrastructure.DataSources.MockDataSources
{
    /// <summary>
    /// Mock data source for Capitec Bank transactions.
    /// </summary>
    public class CapitecBankDataSource : IDataSourceProvider
    {
        public string SourceName => "Capitec Bank";

        public DataSourceType SourceType => DataSourceType.Bank;

        public async Task<List<MockTransaction>> GetTransactionsAsync(Guid customerId, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            // Generate realistic banking transactions
            var transactions = new List<MockTransaction>
            {
                new()
                {
                    ExternalTransactionId = "CB-001",
                    Description = "Salary Deposit",
                    MerchantName = "ABC Company",
                    Amount = 25000.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-5),
                    TransactionType = "Credit",
                    Category = "Income",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "Capitec" },
                        { "AccountType", "Savings" },
                        { "TransactionMethod", "EFT" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "CB-002",
                    Description = "Rent Payment",
                    MerchantName = "Property Management",
                    Amount = -8500.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-4),
                    TransactionType = "Debit",
                    Category = "Housing",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "Capitec" },
                        { "AccountType", "Savings" },
                        { "TransactionMethod", "Direct Debit" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "CB-003",
                    Description = "Grocery Purchase",
                    MerchantName = "Checkers",
                    Amount = -1250.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-3),
                    TransactionType = "Debit",
                    Category = "Groceries",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "Capitec" },
                        { "AccountType", "Savings" },
                        { "TransactionMethod", "Card Payment" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "CB-004",
                    Description = "Fuel Purchase",
                    MerchantName = "Shell",
                    Amount = -850.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-2),
                    TransactionType = "Debit",
                    Category = "Transport",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "Capitec" },
                        { "AccountType", "Savings" },
                        { "TransactionMethod", "Card Payment" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "CB-005",
                    Description = "Restaurant Payment",
                    MerchantName = "Ocean Basket",
                    Amount = -450.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-1),
                    TransactionType = "Debit",
                    Category = "Dining",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "Capitec" },
                        { "AccountType", "Savings" },
                        { "TransactionMethod", "Card Payment" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "CB-006",
                    Description = "ATM Withdrawal",
                    MerchantName = "Capitec ATM",
                    Amount = -1000.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-6),
                    TransactionType = "Debit",
                    Category = "Cash Withdrawal",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "Capitec" },
                        { "AccountType", "Savings" },
                        { "TransactionMethod", "ATM" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "CB-007",
                    Description = "Electricity Payment",
                    MerchantName = "City Power",
                    Amount = -1200.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-7),
                    TransactionType = "Debit",
                    Category = "Utilities",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "Capitec" },
                        { "AccountType", "Savings" },
                        { "TransactionMethod", "Online Payment" }
                    }
                }
            };

            return await Task.FromResult(transactions
                .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .ToList());
        }

        public async Task<bool> ValidateConnectionAsync(Guid customerId)
        {
            // Simulate connection validation
            await Task.Delay(100);
            return await Task.FromResult(true);
        }
    }
}
