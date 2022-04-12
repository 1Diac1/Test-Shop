using Test_Shop.Infrastructure.Interfaces.Repositories;
using Test_Shop.Application.Features.Commands.Product;
using System.Threading.Tasks;
using FluentValidation;
using System.Threading;

namespace Test_Shop.Application.Features.Validation.Product
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull().WithMessage("{PropertyName} is null.")
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
           .MustAsync(IsUniqueNameAsync).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");
        }

        private async Task<bool> IsUniqueNameAsync(string name, CancellationToken cancellationToken) =>
            await _productRepository.IsUniqueNameAsync(name);
    }
}
