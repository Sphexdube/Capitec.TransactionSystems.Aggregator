using Microsoft.Extensions.Logging;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Application.Models.Response.V1;
using TransactionSystems.Aggregator.Domain.Entities;
using TransactionSystems.Aggregator.Domain.Interfaces;
using TransactionSystems.Aggregator.Domain.Interfaces.Exceptions;
using TransactionSystems.Aggregator.Domain.Observability.Messages;
using TransactionSystems.Aggregator.Domain.UnitOfWork;

namespace TransactionSystems.Aggregator.Application.Handlers.Request.V1
{
    internal sealed class GetConnectedDataSourcesRequestHandler(
        ILogger<GetConnectedDataSourcesRequestHandler> logger,
        IUnitOfWorkFactory<ITransactionAggregatorUnitOfWork> unitOfWorkFactory)
        : IRequestHandler<GetConnectedDataSourcesRequest, List<DataSourceResponse>>
    {
        public async Task<List<DataSourceResponse>> HandleAsync(GetConnectedDataSourcesRequest request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(InfoMessages.MethodStarted);

            try
            {
                using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

                var customerDataSources = await unitOfWork.CustomerDataSourceRepository
                    .GetByCustomerIdAsync(request.CustomerId, cancellationToken);

                return customerDataSources
                    .Where(cds => cds.DataSource != null)
                    .Select(cds => MapToDataSourceResponse(cds.DataSource!))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new HandlerException(ErrorMessages.HandlerGenericErrorMessage, ex);
            }
        }

        private static DataSourceResponse MapToDataSourceResponse(DataSource dataSource)
        {
            return new DataSourceResponse
            {
                DataSourceId = dataSource.Id,
                SourceName = dataSource.SourceName,
                Type = dataSource.Type,
                Description = dataSource.Description,
                LogoUrl = dataSource.LogoUrl,
                IsActive = dataSource.IsActive,
                CreatedDate = dataSource.CreatedDate,
                LastSyncDate = dataSource.LastSyncDate,
                IsConnected = true
            };
        }
    }
}
