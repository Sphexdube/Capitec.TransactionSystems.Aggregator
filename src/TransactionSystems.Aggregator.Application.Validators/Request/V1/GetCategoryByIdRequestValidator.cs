using FluentValidation;
using System.Net;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Domain.Observability.Messages;

namespace TransactionSystems.Aggregator.Application.Validators.Request.V1
{
    public sealed class GetCategoryByIdRequestValidator : AbstractValidator<GetCategoryByIdRequest>
    {
        public GetCategoryByIdRequestValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage(string.Format(ResponseMessages.RequestValidationFailure, "CategoryId is required"))
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString());
        }
    }
}
