using System.Threading.Tasks;
using Test_Shop.Shared.Models;
using Test_Shop.Shared.Models.Requests;

namespace Test_Shop.Infrastructure.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<Result> LoginAsync(LoginRequest request);
        Task<Result> RegisterAsync(RegisterRequest request);
        Task<Result> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
