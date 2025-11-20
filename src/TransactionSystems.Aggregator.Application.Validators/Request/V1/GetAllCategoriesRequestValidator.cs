using FluentValidation;
using TransactionSystems.Aggregator.Application.Models.Request.V1;

namespace TransactionSystems.Aggregator.Application.Validators.Request.V1
{
    public sealed class GetAllCategoriesRequestValidator : AbstractValidator<GetAllCategoriesRequest>
    {
        public GetAllCategoriesRequestValidator()
        {
        }
    }
}
