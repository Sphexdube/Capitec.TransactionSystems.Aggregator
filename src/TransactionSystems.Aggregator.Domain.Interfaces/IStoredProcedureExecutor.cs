namespace TransactionSystems.Aggregator.Domain.Interfaces
{
    public interface IStoredProcedureExecutor
    {
        public Task<IEnumerable<T>> ExecuteAsync<T>(string connectionString, string storedProcecureName,
            Dictionary<string, object>? parameters = null);
    }
}
