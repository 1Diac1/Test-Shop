using Test_Shop.Application.Features.Commands.Identity;
using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FluentValidation;
using System.Threading;

namespace Test_Shop.Application.Features.Validation.Identity
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public RegisterCommandValidator(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.")
                .EmailAddress().WithMessage("'Email' is an invalid email address.")
                .MustAsync(IsUniqueEmailAsync).WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");
                

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.")
                .Equal(x => x.Password).WithMessage("Passwords do not match.");
        }

        private async Task<bool> IsUniqueEmailAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);

            return user is null;
        }
    }
}
