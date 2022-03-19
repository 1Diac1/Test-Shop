using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Test_Shop.Application.Common.Models.Requests;
using Test_Shop.Application.Common.Models.Responses;
using Test_Shop.Application.Interfaces.Services;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Identity.Helpers;

namespace Test_Shop.Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly AuthenticationHelper _authenticationHelper;
        private readonly RefreshTokenHelper _refreshTokenHelper;

        public IdentityService(
            AuthenticationHelper authenticationHelper, 
            RefreshTokenHelper refreshTokenHelper)
        {
            _authenticationHelper = authenticationHelper;
            _refreshTokenHelper = refreshTokenHelper;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var loginResponse = await _authenticationHelper.LoginUserHandlerAsync(request);

            return loginResponse;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var registerResponse = await _authenticationHelper.RegisterUserHandlerAsync(request);

            return registerResponse;
        }

        public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var refreshTokenResponse = await _refreshTokenHelper.RefreshTokenHandlerAsync(request);

            return refreshTokenResponse;
        }
    }
}
