using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Application.Validators.Request.V1;

namespace TransactionSystems.Aggregator.Application.Validators.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllCategoriesRequest>, GetAllCategoriesRequestValidator>();
            services.AddScoped<IValidator<GetCategoryByIdRequest>, GetCategoryByIdRequestValidator>();
            services.AddScoped<IValidator<GetCustomerTransactionsRequest>, GetCustomerTransactionsRequestValidator>();
            services.AddScoped<IValidator<GetTransactionByIdRequest>, GetTransactionByIdRequestValidator>();
            services.AddScoped<IValidator<GetTransactionsByCategoryRequest>, GetTransactionsByCategoryRequestValidator>();
            services.AddScoped<IValidator<GetSpendingSummaryRequest>, GetSpendingSummaryRequestValidator>();
            services.AddScoped<IValidator<GetAllDataSourcesRequest>, GetAllDataSourcesRequestValidator>();
            services.AddScoped<IValidator<GetConnectedDataSourcesRequest>, GetConnectedDataSourcesRequestValidator>();

            return services;
        }
    }
}
