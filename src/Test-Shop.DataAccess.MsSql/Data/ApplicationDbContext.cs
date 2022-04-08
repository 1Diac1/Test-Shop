using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Test_Shop.Infrastructure.Interfaces.DataAccess;
using IdentityServer4.EntityFramework.Options;
using Test_Shop.Shared.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Test_Shop.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace Test_Shop.DataAccess.MsSql.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, 
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
