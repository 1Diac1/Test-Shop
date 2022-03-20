using System;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Test_Shop.Application.Interfaces.Services;
using Test_Shop.Domain.Entities;
using Test_Shop.Domain.Settings;
using Test_Shop.Infrastructure.Identity.Data;
using Test_Shop.Infrastructure.Identity.Helpers;
using Test_Shop.Infrastructure.Identity.Services;

namespace Test_Shop.Infrastructure.Identity
{
    public static class DependencyInjection
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            // TODO: change database
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<TokenManager>();
            services.AddScoped<Authenticator>();
            services.AddScoped<RefreshTokenHelper>();
            services.AddScoped<AuthenticationHelper>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();

            services.Configure<JwtConfiguration>(configuration.GetSection("Authentication"));

            var appSettingsKey = configuration.GetValue<string>("Authentication:AccessTokenSecret");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettingsKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim(ClaimsIdentity.DefaultRoleClaimType, "Administrator")));
        }
    }
}
