using Test_Shop.Shared.Models.Requests;
using Test_Shop.Shared.Models;
using System.Threading.Tasks;

namespace Test_Shop.Infrastructure.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<Result> LoginAsync(LoginRequest request);
        Task<Result> RegisterAsync(RegisterRequest request);
        Task<Result> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
