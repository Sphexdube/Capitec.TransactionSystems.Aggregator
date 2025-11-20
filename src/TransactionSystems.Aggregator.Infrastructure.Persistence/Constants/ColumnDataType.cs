namespace TransactionSystems.Aggregator.Infrastructure.Persistence.Constants
{
    public static class ColumnDataType
    {
        public const string Int = "int";
        public const string BigInt = "bigint";
        public const string Money = "money";

        public const string UniqueIdentifier = "uniqueidentifier";

        public const string Nvarchar50 = "nvarchar(50)";
        public const string Nvarchar100 = "nvarchar(100)";
        public const string Nvarchar500 = "nvarchar(500)";
        public const string NvarcharMax = "nvarchar(max)";

        public const string Varchar50 = "varchar(50)";
        public const string Varchar100 = "varchar(100)";
        public const string Varchar500 = "varchar(500)";

        public const string DateTimeOffset = "datetimeoffset";

        public const string Bit = "bit";
    }
}
