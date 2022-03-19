using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Test_Shop.Infrastructure.Identity.Data
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            // TODO: Make connection string to config 
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=test-shop-identity;Trusted_Connection=True;",
                b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));

            return new IdentityContext(optionsBuilder.Options);
        }
    }
}
