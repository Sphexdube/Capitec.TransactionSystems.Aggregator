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
    internal sealed class GetCategoryByIdRequestHandler(
        ILogger<GetCategoryByIdRequestHandler> logger,
        IUnitOfWorkFactory<ITransactionAggregatorUnitOfWork> unitOfWorkFactory)
        : IRequestHandler<GetCategoryByIdRequest, CategoryResponse>
    {
        public async Task<CategoryResponse> HandleAsync(GetCategoryByIdRequest request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation(InfoMessages.MethodStarted);

            try
            {
                using var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

                var category = await unitOfWork.TransactionCategoryRepository
                    .GetByIdAsync(request.CategoryId, cancellationToken);

                if (category is null)
                {
                    throw new HandlerException($"Category with ID {request.CategoryId} not found.");
                }

                return MapToCategoryResponse(category);
            }
            catch (HandlerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HandlerException(ErrorMessages.HandlerGenericErrorMessage, ex);
            }
        }

        private static CategoryResponse MapToCategoryResponse(TransactionCategory category)
        {
            return new CategoryResponse
            {
                CategoryId = category.Id,
                Name = category.Name,
                Description = category.Description,
                Icon = category.Icon,
                ColorCode = category.ColorCode,
                ParentCategoryId = category.ParentCategoryId,
                ParentCategoryName = category.ParentCategory?.Name,
                IsSystemCategory = category.IsSystemCategory,
                SubCategories = category.SubCategories?.Select(MapToCategoryResponse).ToList() ?? []
            };
        }
    }
}
