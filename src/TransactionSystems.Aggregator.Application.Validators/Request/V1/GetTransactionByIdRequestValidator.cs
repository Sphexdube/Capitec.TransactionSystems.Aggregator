using FluentValidation;
using System.Net;
using TransactionSystems.Aggregator.Application.Models.Request.V1;
using TransactionSystems.Aggregator.Domain.Observability.Messages;

namespace TransactionSystems.Aggregator.Application.Validators.Request.V1
{
    public sealed class GetTransactionByIdRequestValidator : AbstractValidator<GetTransactionByIdRequest>
    {
        public GetTransactionByIdRequestValidator()
        {
            RuleFor(x => x.TransactionId)
                .NotEmpty()
                .WithMessage(string.Format(ResponseMessages.RequestValidationFailure, "TransactionId is required"))
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString());
        }
    }
}
