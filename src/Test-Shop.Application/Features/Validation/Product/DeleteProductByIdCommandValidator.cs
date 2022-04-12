using Test_Shop.Application.Features.Commands.Product;
using FluentValidation;

namespace Test_Shop.Application.Features.Validation.Product
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
