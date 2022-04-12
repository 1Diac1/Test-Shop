using Test_Shop.Shared.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Test_Shop.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace Test_Shop.Infrastructure.Interfaces.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<RefreshToken> RefreshTokens { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Product> Products { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
