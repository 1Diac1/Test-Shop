using Test_Shop.Application.Features.Queries.Identity;
using FluentValidation;

namespace Test_Shop.Application.Features.Validation.Identity
{
    public class EmailConfirmationQueryValidator : AbstractValidator<EmailConfirmationQuery>
    {
        public EmailConfirmationQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");

            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");
        }
    }
}
