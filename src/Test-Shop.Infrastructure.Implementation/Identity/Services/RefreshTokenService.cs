using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Test_Shop.Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Test_Shop.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

namespace Test_Shop.Infrastructure.Implementation.Identity.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public RefreshTokenService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> CreateAsync(RefreshToken refreshToken)
        {
            try
            {
                await _applicationDbContext.RefreshTokens.AddAsync(refreshToken);
                await _applicationDbContext.SaveChangesAsync(CancellationToken.None);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var refreshToken = await _applicationDbContext.RefreshTokens
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (refreshToken is null)
                    return false;

                _applicationDbContext.RefreshTokens.Remove(refreshToken);
                await _applicationDbContext.SaveChangesAsync(CancellationToken.None);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAllAsync(string userId)
        {
            try
            {
                IEnumerable<RefreshToken> refreshTokens = await _applicationDbContext.RefreshTokens
                    .Where(t => t.UserId == userId)
                    .ToListAsync();

                _applicationDbContext.RefreshTokens.RemoveRange(refreshTokens);
                await _applicationDbContext.SaveChangesAsync(CancellationToken.None);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<RefreshToken> GetTokenAsync(string token)
        {
            var refreshToken = await _applicationDbContext.RefreshTokens
                .FirstOrDefaultAsync(t => t.Token == token);

            return refreshToken;
        }
    }
}
