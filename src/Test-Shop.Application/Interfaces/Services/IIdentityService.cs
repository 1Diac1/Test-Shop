using System.Threading.Tasks;
using Test_Shop.Application.Common.Models.Requests;
using Test_Shop.Application.Common.Models.Responses;

namespace Test_Shop.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
