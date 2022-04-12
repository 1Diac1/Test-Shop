using Test_Shop.Application.Features.Commands.Identity;
using Test_Shop.Infrastructure.Interfaces.Services;
using Test_Shop.Application.Common.Exceptions;
using Test_Shop.Shared.Models;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace Test_Shop.Application.Features.Handlers.Identity
{
    public class LogoutCommandHandler
        : IRequestHandler<LogoutCommand, Result>
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ICurrentUserService _currentUserService;

        public LogoutCommandHandler(
            IRefreshTokenService refreshTokenService, 
            ICurrentUserService currentUserService)
        {
            _refreshTokenService = refreshTokenService;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            if (userId is null)
                throw new BadRequestException("User not found.");

            var result = await _refreshTokenService.DeleteAllAsync(userId);

            if (result is false)
                throw new BadRequestException("Some error has occurred.");

            return Result.Success();
        }
    }
}
