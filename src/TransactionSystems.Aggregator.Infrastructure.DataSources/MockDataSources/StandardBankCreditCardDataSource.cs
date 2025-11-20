using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Infrastructure.DataSources.MockDataSources
{
    /// <summary>
    /// Mock data source for Standard Bank Credit Card transactions.
    /// </summary>
    public class StandardBankCreditCardDataSource : IDataSourceProvider
    {
        public string SourceName => "Standard Bank Credit Card";

        public DataSourceType SourceType => DataSourceType.CreditCard;

        public async Task<List<MockTransaction>> GetTransactionsAsync(Guid customerId, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            // Generate realistic credit card transactions
            var transactions = new List<MockTransaction>
            {
                new()
                {
                    ExternalTransactionId = "SBCC-001",
                    Description = "Online Purchase - Electronics",
                    MerchantName = "Incredible Connection",
                    Amount = -8999.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-3),
                    TransactionType = "Debit",
                    Category = "Shopping",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "MCC", "5732" },
                        { "TransactionMethod", "Online" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SBCC-002",
                    Description = "Restaurant - Fine Dining",
                    MerchantName = "The Meat Co",
                    Amount = -1850.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-2),
                    TransactionType = "Debit",
                    Category = "Dining",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "MCC", "5812" },
                        { "TransactionMethod", "Chip & Pin" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SBCC-003",
                    Description = "Flight Booking",
                    MerchantName = "FlySafair",
                    Amount = -2450.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-1),
                    TransactionType = "Debit",
                    Category = "Travel",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "MCC", "4511" },
                        { "TransactionMethod", "Online" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SBCC-004",
                    Description = "Clothing Purchase",
                    MerchantName = "Truworths",
                    Amount = -3200.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-4),
                    TransactionType = "Debit",
                    Category = "Shopping",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "MCC", "5651" },
                        { "TransactionMethod", "Chip & Pin" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SBCC-005",
                    Description = "Gym Membership",
                    MerchantName = "Virgin Active",
                    Amount = -599.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-5),
                    TransactionType = "Debit",
                    Category = "Health & Fitness",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "MCC", "7997" },
                        { "TransactionMethod", "Recurring" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SBCC-006",
                    Description = "Pharmacy",
                    MerchantName = "Dis-Chem",
                    Amount = -650.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-6),
                    TransactionType = "Debit",
                    Category = "Healthcare",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "MCC", "5912" },
                        { "TransactionMethod", "Contactless" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SBCC-007",
                    Description = "Hotel Accommodation",
                    MerchantName = "Protea Hotels",
                    Amount = -4500.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-7),
                    TransactionType = "Debit",
                    Category = "Travel",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "MCC", "3501" },
                        { "TransactionMethod", "Online" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SBCC-008",
                    Description = "Credit Card Payment",
                    MerchantName = "Standard Bank",
                    Amount = 5000.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-8),
                    TransactionType = "Credit",
                    Category = "Payment",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "TransactionMethod", "EFT" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SBCC-009",
                    Description = "Spotify Premium",
                    MerchantName = "Spotify",
                    Amount = -119.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-9),
                    TransactionType = "Debit",
                    Category = "Entertainment",
                    Metadata = new Dictionary<string, string>
                    {
                        { "CardType", "Visa" },
                        { "CardLast4", "4582" },
                        { "MCC", "5815" },
                        { "TransactionMethod", "Recurring" }
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
