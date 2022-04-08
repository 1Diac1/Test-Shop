using Test_Shop.Application.Features.Commands;
using FluentValidation;

namespace Test_Shop.Application.Features.Validation
{
    public class DeleteProductByIdCommandValidator : AbstractValidator<DeleteProductByIdCommand>
    {
        public DeleteProductByIdCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");
        }
    }
}
