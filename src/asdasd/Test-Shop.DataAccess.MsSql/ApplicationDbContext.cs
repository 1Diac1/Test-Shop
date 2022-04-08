using Microsoft.EntityFrameworkCore;
using Test_Shop.Entities.Models;
using Test_Shop.Infrastructure.Interfaces.DataAccess;

namespace Test_Shop.DataAccess.MsSql
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<Product> Products { get; }
        public DbSet<OrderItem> OrderDetails { get; }
        public DbSet<RefreshToken> RefreshTokens { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


    }
}
