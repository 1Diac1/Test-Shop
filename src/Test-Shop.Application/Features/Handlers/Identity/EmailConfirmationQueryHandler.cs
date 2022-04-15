using Test_Shop.Application.Features.Queries.Identity;
using Test_Shop.Application.Common.Exceptions;
using Test_Shop.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Test_Shop.Shared.Extensions;
using Test_Shop.Shared.Models;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace Test_Shop.Application.Features.Handlers.Identity
{
    public class EmailConfirmationQueryHandler
        : IRequestHandler<EmailConfirmationQuery, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailConfirmationQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // TODO: Validator
        public async Task<Result> Handle(EmailConfirmationQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null)
                throw new NotFoundException(nameof(ApplicationUser), cancellationToken);

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            return result.ToApplicationResult();
        }
    }
}
