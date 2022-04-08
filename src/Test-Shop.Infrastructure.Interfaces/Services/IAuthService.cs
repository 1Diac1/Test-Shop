using System.Threading.Tasks;
using Test_Shop.Shared.Models;

namespace Test_Shop.Infrastructure.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

    }
}
