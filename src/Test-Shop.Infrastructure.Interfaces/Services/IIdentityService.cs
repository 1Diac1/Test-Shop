using System.Threading.Tasks;
using Test_Shop.Common.Requests;
using Test_Shop.Common.Responses;

namespace Test_Shop.Infrastructure.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
