using Test_Shop.Infrastructure.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Test_Shop.Infrastructure.Implementation;
using Microsoft.Extensions.Configuration;
using Test_Shop.DataAccess.MsSql.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Test_Shop.DataAccess.MsSql;
using Test_Shop.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Test_Shop.WebAPI.Filters;
using Test_Shop.Application;

namespace Test_Shop.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccessMsSqlServices(Configuration);
            services.AddInfrastructureServices(Configuration);
            services.AddApplicationServices();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddControllers(options =>
                    options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test-Shop API v1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
