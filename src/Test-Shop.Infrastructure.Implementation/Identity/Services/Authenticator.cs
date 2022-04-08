using Test_Shop.Infrastructure.Interfaces.Services;
using Test_Shop.Shared.Models.Identity;
using Test_Shop.Domain.Entities;
using Test_Shop.Shared.Models;
using System.Threading.Tasks;

namespace Test_Shop.Infrastructure.Implementation.Identity.Services
{
    public class Authenticator
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly TokenManager _tokenService;

        public Authenticator(IRefreshTokenService refreshTokenService, TokenManager tokenService)
        {
            _refreshTokenService = refreshTokenService;
            _tokenService = tokenService;
        }

        public async Task<Result> Authenticate(ApplicationUser user)
        {
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var result = await _refreshTokenService.CreateAsync(new RefreshToken(refreshToken, user.Id));

            return result is false
                ? Result.Failure("There Was Some Kind Of Mistake.")
                : Result.SuccessAuth(accessToken, refreshToken);
        }
    }
}
