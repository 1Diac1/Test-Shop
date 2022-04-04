using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test_Shop.Infrastructure.Interfaces.DataAccess;

namespace Test_Shop.DataAccess.MsSql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessMsSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDbContext, ApplicationDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
