using Dapper;
using Microsoft.Data.SqlClient;
using TransactionSystems.Aggregator.Domain.Interfaces;
using TransactionSystems.Aggregator.Domain.Observability.Messages;
using TransactionSystems.Aggregator.Infrastructure.StoredProcedures.Exceptions;
using System.Data;

namespace TransactionSystems.Aggregator.Infrastructure.StoredProcedures
{
    public sealed class DapperStoredProcedureExecutor : IStoredProcedureExecutor
    {
        private const int _commandTimeout = 600;

        public async Task<IEnumerable<T>> ExecuteAsync<T>(string connectionString,
            string storedProcecureName,
            Dictionary<string, object>? parameters = null)
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    if (parameters != null && parameters.Count != 0)
                    {
                        DynamicParameters dynamicParameters = new();
                        foreach (KeyValuePair<string, object> entry in parameters)
                        {
                            dynamicParameters.Add(entry.Key, entry.Value);
                        }

                        return await connection
                            .QueryAsync<T>(storedProcecureName, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: _commandTimeout);
                    }

                    return await connection
                        .QueryAsync<T>(storedProcecureName, commandType: CommandType.StoredProcedure, commandTimeout: _commandTimeout);
                }
            }
            catch (Exception ex)
            {
                throw new StoredProcedureFailedToExecuteException(ErrorMessages.StoredProcedureFailedToExecuteErrorMessage, ex);
            }
        }
    }
}
