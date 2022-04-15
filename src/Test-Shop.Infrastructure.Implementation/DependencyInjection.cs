using Test_Shop.Infrastructure.Implementation.Persistence.Repositories;
using Test_Shop.Infrastructure.Implementation.Identity.Services;
using Test_Shop.Infrastructure.Implementation.Settings;
using Test_Shop.Infrastructure.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Test_Shop.Infrastructure.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Test_Shop.Shared.Models.Identity;
using Test_Shop.DataAccess.MsSql.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Reflection;
using System.Text;
using System;

namespace Test_Shop.Infrastructure.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<TokenManager>();
            services.AddScoped<Authenticator>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Configure<EmailConfiguration>(configuration.GetSection("EmailConfiguration"));
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
            services.Configure<EmailRoute>(configuration.GetSection("EmailRoute"));

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfiguration:AccessTokenSecret"])),
                        ValidIssuer = configuration["JwtConfiguration:Issuer"],
                        ValidAudience = configuration["JwtConfiguration:Audience"],
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization(options =>
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim(ClaimsIdentity.DefaultRoleClaimType, "Administrator")));

            return services;
        }
    }
}
