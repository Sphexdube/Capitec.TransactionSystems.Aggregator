using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Infrastructure.DataSources.MockDataSources
{
    /// <summary>
    /// Mock data source for First National Bank (FNB) transactions.
    /// </summary>
    public class FNBBankDataSource : IDataSourceProvider
    {
        public string SourceName => "First National Bank (FNB)";

        public DataSourceType SourceType => DataSourceType.Bank;

        public async Task<List<MockTransaction>> GetTransactionsAsync(Guid customerId, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            // Generate realistic FNB banking transactions
            var transactions = new List<MockTransaction>
            {
                new()
                {
                    ExternalTransactionId = "FNB-2024-001",
                    Description = "Freelance Payment",
                    MerchantName = "Client XYZ",
                    Amount = 15000.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-4),
                    TransactionType = "Credit",
                    Category = "Income",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "FNB" },
                        { "AccountType", "Cheque" },
                        { "TransactionMethod", "EFT" },
                        { "Reference", "INV-001" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "FNB-2024-002",
                    Description = "Medical Aid",
                    MerchantName = "Discovery Health",
                    Amount = -2450.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-3),
                    TransactionType = "Debit",
                    Category = "Healthcare",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "FNB" },
                        { "AccountType", "Cheque" },
                        { "TransactionMethod", "Debit Order" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "FNB-2024-003",
                    Description = "Online Shopping",
                    MerchantName = "Takealot",
                    Amount = -3250.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-2),
                    TransactionType = "Debit",
                    Category = "Shopping",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "FNB" },
                        { "AccountType", "Cheque" },
                        { "TransactionMethod", "Online Payment" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "FNB-2024-004",
                    Description = "Grocery Shopping",
                    MerchantName = "Pick n Pay",
                    Amount = -1850.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-1),
                    TransactionType = "Debit",
                    Category = "Groceries",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "FNB" },
                        { "AccountType", "Cheque" },
                        { "TransactionMethod", "Card Payment" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "FNB-2024-005",
                    Description = "Coffee Shop",
                    MerchantName = "Vida e Caffe",
                    Amount = -95.00m,
                    TransactionDate = DateTimeOffset.Now.AddHours(-12),
                    TransactionType = "Debit",
                    Category = "Dining",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "FNB" },
                        { "AccountType", "Cheque" },
                        { "TransactionMethod", "Card Payment" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "FNB-2024-006",
                    Description = "Insurance Premium",
                    MerchantName = "Old Mutual",
                    Amount = -1800.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-5),
                    TransactionType = "Debit",
                    Category = "Insurance",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "FNB" },
                        { "AccountType", "Cheque" },
                        { "TransactionMethod", "Debit Order" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "FNB-2024-007",
                    Description = "Uber Rides",
                    MerchantName = "Uber South Africa",
                    Amount = -420.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-6),
                    TransactionType = "Debit",
                    Category = "Transport",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "FNB" },
                        { "AccountType", "Cheque" },
                        { "TransactionMethod", "Card Payment" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "FNB-2024-008",
                    Description = "Netflix Subscription",
                    MerchantName = "Netflix",
                    Amount = -199.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-7),
                    TransactionType = "Debit",
                    Category = "Entertainment",
                    Metadata = new Dictionary<string, string>
                    {
                        { "SourceBank", "FNB" },
                        { "AccountType", "Cheque" },
                        { "TransactionMethod", "Card Payment" }
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
