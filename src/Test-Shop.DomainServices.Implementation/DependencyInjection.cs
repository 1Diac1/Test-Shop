using Microsoft.Extensions.DependencyInjection;
using Test_Shop.DomainServices.Interfaces;

namespace Test_Shop.DomainServices.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderDomainService, OrderDomainService>();

            return services;
        }
    }
}
