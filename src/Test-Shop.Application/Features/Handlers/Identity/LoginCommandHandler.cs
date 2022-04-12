using Test_Shop.Application.Features.Commands.Identity;
using Test_Shop.Infrastructure.Interfaces.Services;
using Test_Shop.Application.Common.Exceptions;
using Test_Shop.Shared.Models.Requests;
using Test_Shop.Shared.Models;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace Test_Shop.Application.Features.Handlers.Identity
{
    public class LoginCommandHandler 
        : IRequestHandler<LoginCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public LoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginRequest = new LoginRequest(request.Email, request.Password);
            var result = await _identityService.LoginAsync(loginRequest);

            if (result.Succeeded is false)
                throw new BadRequestException("Login or Password don't correct.");

            return result;
        }
    }
}
