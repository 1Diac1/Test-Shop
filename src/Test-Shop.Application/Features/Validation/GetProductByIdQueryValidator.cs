using Test_Shop.Application.Features.Queries;
using FluentValidation;

namespace Test_Shop.Application.Features.Validation
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");
        }
    }
}
