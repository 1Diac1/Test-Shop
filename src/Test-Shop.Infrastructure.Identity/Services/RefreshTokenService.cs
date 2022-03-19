using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_Shop.Application.Interfaces.Services;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Identity.Data;

namespace Test_Shop.Infrastructure.Identity.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IdentityContext _context;

        public RefreshTokenService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(RefreshToken refreshToken)
        {
            try
            {
                await _context.RefreshTokens.AddAsync(refreshToken);
                await _context.SaveChangesAsync();
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
                var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Id == id);

                if (refreshToken is null)
                    return false;

                _context.RefreshTokens.Remove(refreshToken);
                await _context.SaveChangesAsync();
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
                IEnumerable<RefreshToken> refreshTokens = await _context.RefreshTokens
                    .Where(t => t.UserId == userId)
                    .ToListAsync();

                _context.RefreshTokens.RemoveRange(refreshTokens);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<RefreshToken> GetTokenAsync(string token)
        {
            var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);

            return refreshToken ?? null;
        }
    }
}
