using Microsoft.Extensions.DependencyInjection;
using TransactionSystems.Aggregator.Application.Handlers.Request.V1;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Application.Models.Response.V1;
using TransactionSystems.Aggregator.Domain.Interfaces;

namespace TransactionSystems.Aggregator.Application.Handlers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetAllCategoriesRequest, List<CategoryResponse>>, GetAllCategoriesRequestHandler>();
            services.AddScoped<IRequestHandler<GetCategoryByIdRequest, CategoryResponse>, GetCategoryByIdRequestHandler>();
            services.AddScoped<IRequestHandler<GetCustomerTransactionsRequest, List<TransactionResponse>>, GetCustomerTransactionsRequestHandler>();
            services.AddScoped<IRequestHandler<GetTransactionByIdRequest, TransactionResponse>, GetTransactionByIdRequestHandler>();
            services.AddScoped<IRequestHandler<GetTransactionsByCategoryRequest, Dictionary<string, List<TransactionResponse>>>, GetTransactionsByCategoryRequestHandler>();
            services.AddScoped<IRequestHandler<GetSpendingSummaryRequest, SpendingSummaryResponse>, GetSpendingSummaryRequestHandler>();
            services.AddScoped<IRequestHandler<GetAllDataSourcesRequest, List<DataSourceResponse>>, GetAllDataSourcesRequestHandler>();
            services.AddScoped<IRequestHandler<GetConnectedDataSourcesRequest, List<DataSourceResponse>>, GetConnectedDataSourcesRequestHandler>();

            return services;
        }
    }
}
