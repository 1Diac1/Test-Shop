using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Shop.Application.Common.Models.Responses;
using Test_Shop.Application.Interfaces.Services;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Infrastructure.Identity.Services
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

        public async Task<AuthResponse> Authenticate(User user)
        {
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var response = await _refreshTokenService.CreateAsync(new RefreshToken { Token = refreshToken, UserId = user.Id });

            if (response is false)
                return new AuthResponse( "There Was Some Kind Of Mistake.");

            return new AuthResponse
            {
                Success = true,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
