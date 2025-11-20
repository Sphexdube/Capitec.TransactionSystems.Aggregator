using TransactionSystems.Aggregator.Application.BackgroundJobs.Exceptions;
using TransactionSystems.Aggregator.Domain.Observability.Messages;
using Microsoft.Extensions.Configuration;

namespace TransactionSystems.Aggregator.Domain.Interfaces
{
    public sealed class DatabaseArchivingBackgroundJob(
        IObservabilityManager observabilityManager,
        IStoredProcedureExecutor storedProcedureExecutor,
        IConfiguration configuration) : IJob
    {
        public async Task DoJob()
        {
            observabilityManager.LogMessage(InfoMessages.MethodStarted).AsInfo();

            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

                string storedProcedureName = configuration["BackgroundJobs:ArchiveStoredProcedure"] ?? "usp_ArchiveData";

                bool storedProcedureResult = (await storedProcedureExecutor.ExecuteAsync<bool>(
                    connectionString,
                    storedProcedureName)).FirstOrDefault();

                if (!storedProcedureResult)
                {
                    throw new BackgroundJobExecutionException(string.Format(
                        ErrorMessages.BackgroundjobStoredProcedureFailedToExecuteErrorMessage,
                        storedProcedureName));
                }
            }
            catch (Exception ex)
            {
                observabilityManager
                    .LogMessage(ErrorMessages.BackgroundjobGeneralErrorMessage)
                    .AsError(ex);
            }
        }
    }
}
