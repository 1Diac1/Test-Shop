using Test_Shop.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace Test_Shop.Infrastructure.Interfaces.Services
{
    public interface IRefreshTokenService
    {
        Task<bool> CreateAsync(RefreshToken refreshToken);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAllAsync(string userId);
        Task<RefreshToken> GetTokenAsync(string token);
    }
}
