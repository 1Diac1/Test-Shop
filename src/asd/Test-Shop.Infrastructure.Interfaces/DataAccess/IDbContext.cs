using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Test_Shop.Entities.Models;

namespace Test_Shop.Infrastructure.Interfaces.DataAccess
{
    public interface IDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Order> Orders { get; }
        DbSet<Product> Products { get; }
        DbSet<OrderItem> OrderDetails { get; }
        DbSet<RefreshToken> RefreshTokens { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNull] TEntity entity,
            CancellationToken cancellationToken = default) where TEntity : class;
    }
}
