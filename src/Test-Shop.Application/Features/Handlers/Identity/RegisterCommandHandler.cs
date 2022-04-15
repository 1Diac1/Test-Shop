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
    public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public RegisterCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerRequest = new RegisterRequest(
                request.FirstName, request.LastName, request.Email, request.PhoneNumber, request.Password, request.ConfirmPassword);
            var result = await _identityService.RegisterAsync(registerRequest);

            if (result.Succeeded is false)
                throw new BadRequestException(result.Errors);

            return result;
        }
    }
}
