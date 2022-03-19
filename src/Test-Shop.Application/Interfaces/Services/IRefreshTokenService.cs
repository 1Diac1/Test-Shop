using System;
using System.Threading.Tasks;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Interfaces.Services
{
    public interface IRefreshTokenService
    {
        Task<bool> CreateAsync(RefreshToken refreshToken);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAllAsync(string userId);
        Task<RefreshToken> GetTokenAsync(string token);
    }
}
