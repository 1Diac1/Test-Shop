using Test_Shop.Infrastructure.Interfaces.Services;
using Test_Shop.Shared.Models.Identity;
using Test_Shop.Shared.Models.Requests;
using Microsoft.AspNetCore.Identity;
using Test_Shop.Shared.Extensions;
using Test_Shop.Shared.Models;
using System.Threading.Tasks;

namespace Test_Shop.Infrastructure.Implementation.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Authenticator _authenticator;
        private readonly IEmailService _emailService;
        private readonly TokenManager _tokenManager;

        public IdentityService(
            IRefreshTokenService refreshTokenService,
            UserManager<ApplicationUser> userManager,
            Authenticator authenticator,
            IEmailService emailService,
            TokenManager tokenManager)
        {
            _refreshTokenService = refreshTokenService;
            _userManager = userManager;
            _authenticator = authenticator;
            _emailService = emailService;
            _tokenManager = tokenManager;
        }

        public async Task<Result> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (result is false)
                return new Result().FailurePasswordMismatch();

            var response = await _authenticator.Authenticate(user);

            return response;
        }

        public async Task<Result> RegisterAsync(RegisterRequest request)
        {
            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (result.Succeeded is false)
                return result.ToApplicationResult();

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var confirmationLink = _emailService.GenerateConfirmationLink(newUser.Id, token);

            await _emailService.SendEmailAsync(
                "askdjk123sd1@gmail.com", 
                "Confirmation email link",
                $"Confirm your registration by following the <a href='{confirmationLink.Result}'>link</a>.");

            var response = await _authenticator.Authenticate(newUser);

            return response;
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
