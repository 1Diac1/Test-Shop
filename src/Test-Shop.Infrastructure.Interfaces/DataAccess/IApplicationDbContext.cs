using Microsoft.EntityFrameworkCore;
using Test_Shop.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace Test_Shop.Infrastructure.Interfaces.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<RefreshToken> RefreshTokens { get; set; }
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
