using FluentValidation;
using System.Net;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Domain.Observability.Messages;

namespace TransactionSystems.Aggregator.Application.Validators.Request.V1
{
    public sealed class GetCustomerTransactionsRequestValidator : AbstractValidator<GetCustomerTransactionsRequest>
    {
        public GetCustomerTransactionsRequestValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage(string.Format(ResponseMessages.RequestValidationFailure, "CustomerId is required"))
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString());
        }
    }
}
