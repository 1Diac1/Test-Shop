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
    public class RefreshTokenCommandHandler
        : IRequestHandler<RefreshTokenCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public RefreshTokenCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshTokenRequest = new RefreshTokenRequest(request.RefreshToken);
            var result = await _identityService.RefreshTokenAsync(refreshTokenRequest);

            if (result.Succeeded is false)
                throw new BadRequestException(result.Errors);

            return result;
        }
    }
}
