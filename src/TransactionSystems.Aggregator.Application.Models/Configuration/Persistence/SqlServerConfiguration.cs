using Microsoft.Data.SqlClient;

namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.Persistence
{
    [Serializable]
    public sealed class SqlServerConfiguration
    {
        public required string Server { get; init; }
        public required string Database { get; init; }
        public required string Username { get; init; }
        public required string Password { get; init; }

        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = Server,
                InitialCatalog = Database,
                UserID = Username,
                Password = Password,
                TrustServerCertificate = true
            };

            return builder.ConnectionString;
        }
    }
}
