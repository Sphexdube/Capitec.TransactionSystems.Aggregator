using TransactionSystems.Aggregator.Domain.Models.Enumerations;

namespace TransactionSystems.Aggregator.Infrastructure.DataSources.MockDataSources
{
    /// <summary>
    /// Mock data source for SnapScan (Payment App) transactions.
    /// </summary>
    public class SnapScanDataSource : IDataSourceProvider
    {
        public string SourceName => "SnapScan";

        public DataSourceType SourceType => DataSourceType.PaymentApp;

        public async Task<List<MockTransaction>> GetTransactionsAsync(Guid customerId, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            // Generate realistic SnapScan payment app transactions
            var transactions = new List<MockTransaction>
            {
                new()
                {
                    ExternalTransactionId = "SS-TXN-001",
                    Description = "Coffee & Pastry",
                    MerchantName = "Seattle Coffee Co",
                    Amount = -85.00m,
                    TransactionDate = DateTimeOffset.Now.AddHours(-6),
                    TransactionType = "Debit",
                    Category = "Dining",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12345" },
                        { "MerchantCode", "SCC-001" },
                        { "PaymentMethod", "QR Code Scan" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SS-TXN-002",
                    Description = "Parking Fee",
                    MerchantName = "CPT City Parking",
                    Amount = -40.00m,
                    TransactionDate = DateTimeOffset.Now.AddHours(-10),
                    TransactionType = "Debit",
                    Category = "Transport",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12346" },
                        { "MerchantCode", "PARK-002" },
                        { "PaymentMethod", "QR Code Scan" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SS-TXN-003",
                    Description = "Street Vendor - Food",
                    MerchantName = "Daily Eats",
                    Amount = -120.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-1),
                    TransactionType = "Debit",
                    Category = "Dining",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12347" },
                        { "MerchantCode", "DE-003" },
                        { "PaymentMethod", "QR Code Scan" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SS-TXN-004",
                    Description = "Tip Payment",
                    MerchantName = "Ocean Basket",
                    Amount = -50.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-1).AddHours(-2),
                    TransactionType = "Debit",
                    Category = "Dining",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12348" },
                        { "MerchantCode", "OB-004" },
                        { "PaymentMethod", "QR Code Scan" },
                        { "TransactionNote", "Tip" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SS-TXN-005",
                    Description = "Fuel Payment",
                    MerchantName = "Engen",
                    Amount = -650.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-2),
                    TransactionType = "Debit",
                    Category = "Transport",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12349" },
                        { "MerchantCode", "ENG-005" },
                        { "PaymentMethod", "QR Code Scan" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SS-TXN-006",
                    Description = "Bakery Purchase",
                    MerchantName = "Knead Bakery",
                    Amount = -145.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-3),
                    TransactionType = "Debit",
                    Category = "Groceries",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12350" },
                        { "MerchantCode", "KB-006" },
                        { "PaymentMethod", "QR Code Scan" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SS-TXN-007",
                    Description = "Car Wash",
                    MerchantName = "Shine & Sparkle",
                    Amount = -80.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-4),
                    TransactionType = "Debit",
                    Category = "Transport",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12351" },
                        { "MerchantCode", "SS-007" },
                        { "PaymentMethod", "QR Code Scan" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SS-TXN-008",
                    Description = "Farmer's Market",
                    MerchantName = "Organic Market",
                    Amount = -320.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-5),
                    TransactionType = "Debit",
                    Category = "Groceries",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12352" },
                        { "MerchantCode", "OM-008" },
                        { "PaymentMethod", "QR Code Scan" }
                    }
                },
                new()
                {
                    ExternalTransactionId = "SS-TXN-009",
                    Description = "Refund - Cancelled Order",
                    MerchantName = "Daily Eats",
                    Amount = 120.00m,
                    TransactionDate = DateTimeOffset.Now.AddDays(-6),
                    TransactionType = "Credit",
                    Category = "Refund",
                    Metadata = new Dictionary<string, string>
                    {
                        { "PaymentApp", "SnapScan" },
                        { "QRCode", "SS-QR-12353" },
                        { "MerchantCode", "DE-003" },
                        { "PaymentMethod", "Refund" },
                        { "OriginalTxn", "SS-TXN-003" }
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
