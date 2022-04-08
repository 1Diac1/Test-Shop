using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Test_Shop.DataAccess.MsSql.Data;
using Microsoft.EntityFrameworkCore;

namespace Test_Shop.DataAccess.MsSql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessMsSqlServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
