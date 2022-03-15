using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test_Shop.Application.Interfaces.Repositories;
using Test_Shop.Infrastructure.Persistence.Data;
using Test_Shop.Infrastructure.Persistence.Implementation.Repositories;

namespace Test_Shop.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        }
    }
}
