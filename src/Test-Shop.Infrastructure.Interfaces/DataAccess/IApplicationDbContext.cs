using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Infrastructure.Interfaces.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<RefreshToken> RefreshTokens { get; set; }
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
