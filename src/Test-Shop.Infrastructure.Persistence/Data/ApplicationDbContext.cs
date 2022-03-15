using Microsoft.EntityFrameworkCore;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }
}
