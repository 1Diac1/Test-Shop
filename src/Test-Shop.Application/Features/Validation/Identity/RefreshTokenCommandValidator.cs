using Test_Shop.Application.Features.Commands.Identity;
using FluentValidation;

namespace Test_Shop.Application.Features.Validation.Identity
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");
        }
    }
}
