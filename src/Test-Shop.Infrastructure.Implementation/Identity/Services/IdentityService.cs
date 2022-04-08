using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Test_Shop.Infrastructure.Interfaces.Services;
using Test_Shop.Shared.Models;
using Test_Shop.Shared.Models.Identity;
using Test_Shop.Shared.Models.Requests;

namespace Test_Shop.Infrastructure.Implementation.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly Authenticator _authenticator;
        private readonly TokenManager _tokenManager;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            IRefreshTokenService refreshTokenService,
            Authenticator authenticator, 
            TokenManager tokenManager)
        {
            _userManager = userManager;
            _refreshTokenService = refreshTokenService;
            _authenticator = authenticator;
            _tokenManager = tokenManager;
        }

        public async Task<Result> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                return Result.Failure("Login or Password don't correct.");

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (result is false)
                return Result.Failure("Login or Password don't correct.");

            var authenticate = await _authenticator.Authenticate(user);

            return authenticate;
        }

        public async Task<Result> RegisterAsync(RegisterRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (!(user is null))
                return Result.Failure("User with this Email already exists."); //Password mismatch.

            if (!string.Equals(request.Password, request.ConfirmPassword, StringComparison.Ordinal))
                return Result.Failure("Password mismatch.");

            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            return result.ToApplicationResult();
        }

        public async Task<Result> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var isTokenValid = _tokenManager.ValidateRefreshToken(request.RefreshToken);

            if (isTokenValid is false)
                return Result.Failure("Refresh Token not found.");

            var refreshToken = await _refreshTokenService.GetTokenAsync(request.RefreshToken);

            if (refreshToken is null)
                return Result.Failure("Refresh Token not found.");

            await _refreshTokenService.DeleteAsync(refreshToken.Id);

            var user = await _userManager.FindByIdAsync(refreshToken.UserId);

            var result = await _authenticator.Authenticate(user);

            return result;
        }
    }
}
