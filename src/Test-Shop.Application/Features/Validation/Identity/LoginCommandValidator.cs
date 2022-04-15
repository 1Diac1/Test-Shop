using Test_Shop.Application.Features.Commands.Identity;
using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FluentValidation;
using System.Threading;

namespace Test_Shop.Application.Features.Validation.Identity
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public LoginCommandValidator(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.")
                .MustAsync(IsExistEmailAsync).WithMessage("User with this email not found.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is null.");
        }

        private async Task<bool> IsExistEmailAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);

            return !(user is null);
        }
    }
}
