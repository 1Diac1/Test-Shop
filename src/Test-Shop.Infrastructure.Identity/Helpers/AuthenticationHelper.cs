using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Test_Shop.Application.Common.Models.Requests;
using Test_Shop.Application.Common.Models.Responses;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Identity.Services;

namespace Test_Shop.Infrastructure.Identity.Helpers
{
    public class AuthenticationHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly Authenticator _authenticator;

        public AuthenticationHelper(
            UserManager<User> userManager, 
            Authenticator authenticator)
        {
            _userManager = userManager;
            _authenticator = authenticator;
        }

        public async Task<AuthResponse> LoginUserHandlerAsync(LoginRequest request)
        {
            var (authResponse, user) = await IsExistsUserByEmailWithDataAsync(request.Email, "Login or Password don't correct.");

            if (authResponse.Success is false)
                return authResponse;

            var isPasswordCorrectResponse = await CheckUserPasswordAsync(user, request.Password);

            if (isPasswordCorrectResponse.Success is false)
                return isPasswordCorrectResponse;

            var authenticate = await _authenticator.Authenticate(user);

            return authenticate.Success is true
                ? authenticate
                : ReturnErrorMessage("There Was Some Kind Of Mistake.");
        }

        public async Task<AuthResponse> RegisterUserHandlerAsync(RegisterRequest request)
        {
            var isExistsResponse = await IsExistsUserByEmailAsync(request.Email, "User with this Email already exists.");

            if (isExistsResponse.Success is true)
                return isExistsResponse;

            var isPasswordCorrectResponse = CheckConfirmPassword(request.Password, request.ConfirmPassword);

            if (isPasswordCorrectResponse.Success is false)
                return isPasswordCorrectResponse;

            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await CreateUserAsync(user, request.Password);

            return result;
        }

        private async Task<AuthResponse> CreateUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result.Succeeded is false
                ? ReturnErrorMessages(result.Errors.Select(e => e.Description))
                : SucceededResponse();
        }

        private async Task<AuthResponse> CheckUserPasswordAsync(User user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);

            return result is false
                ? ReturnErrorMessage("Login or Password don't correct.")
                : SucceededResponse();
        }

        private async Task<(AuthResponse authResponse, User user)> IsExistsUserByEmailWithDataAsync(string email, string errorName)
        {   
            var user = await _userManager.FindByEmailAsync(email);

            return user is null 
                ? (ReturnErrorMessage(errorName), null) 
                : (SucceededResponse(), user);
        }

        private async Task<AuthResponse> IsExistsUserByEmailAsync(string email, string errorName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user is null
                ? ReturnErrorMessage(errorName)
                : SucceededResponse();
        }

        private AuthResponse CheckConfirmPassword(string password, string confirmPassword)
        {
            return password != confirmPassword
                ? ReturnErrorMessage("Password mismatch.")
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
