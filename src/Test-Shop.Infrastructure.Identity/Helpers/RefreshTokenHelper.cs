using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Test_Shop.Application.Common.Models.Requests;
using Test_Shop.Application.Common.Models.Responses;
using Test_Shop.Application.Interfaces.Services;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Identity.Services;

namespace Test_Shop.Infrastructure.Identity.Helpers
{
    public class RefreshTokenHelper
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly UserManager<User> _userManager;
        private readonly Authenticator _authenticator;
        private readonly TokenManager _tokenManager;

        public RefreshTokenHelper(
            IRefreshTokenService refreshTokenService,
            UserManager<User> userManager,
            Authenticator authenticator, 
            TokenManager tokenManager)
        {
            _refreshTokenService = refreshTokenService;
            _userManager = userManager;
            _authenticator = authenticator;
            _tokenManager = tokenManager;
        }

        public async Task<AuthResponse> RefreshTokenHandlerAsync(RefreshTokenRequest request)
        {
            var isTokenValidResponse = ValidateRefreshToken(request.RefreshToken);

            if (isTokenValidResponse.Success is false)
                return isTokenValidResponse;

            var (authResponse, refreshToken) = await GetTokenAsync(request.RefreshToken);

            if (authResponse.Success is false)
                return authResponse;

            await _refreshTokenService.DeleteAsync(refreshToken.Id);

            var (response, user) = await IsExistsUserById(refreshToken.UserId);

            if (response.Success is false)
                return response;

            var authenticate = await _authenticator.Authenticate(user);

            return authenticate.Success is true
                ? authenticate
                : ReturnErrorMessage("There Was Some Kind Of Mistake.");
        }

        private async Task<(AuthResponse authResponse, User user)> IsExistsUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user is null
                ? (ReturnErrorMessage("User not found."), null)
                : (SucceededResponse(), user);
        }

        private async Task<(AuthResponse authResponse, RefreshToken refreshToken)> GetTokenAsync(string refreshToken)
        {
            var token = await _refreshTokenService.GetTokenAsync(refreshToken);

            return token is null
                ? (ReturnErrorMessage("Refresh Token not found."), null)
                : (SucceededResponse(), token);
        }

        private AuthResponse ValidateRefreshToken(string refreshToken)
        {
            var isTokenValid = _tokenManager.ValidateRefreshToken(refreshToken);

            return isTokenValid is false
                ? ReturnErrorMessage("Refresh Token not found.")
                : SucceededResponse();
        }

        private AuthResponse ReturnErrorMessages(IEnumerable<string> errors) =>
            new AuthResponse(errors);

        private AuthResponse ReturnErrorMessage(string errorName) =>
            new AuthResponse(errorName);

        private AuthResponse SucceededResponse() =>
            new AuthResponse(true);
    }
}
