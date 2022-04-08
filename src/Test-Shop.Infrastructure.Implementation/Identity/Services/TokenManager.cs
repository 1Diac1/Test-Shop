using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Test_Shop.Infrastructure.Implementation.Settings;
using Test_Shop.Shared.Models.Identity;

namespace Test_Shop.Infrastructure.Implementation.Identity.Services
{
    public class TokenManager
    {
        private readonly JwtConfiguration _jwtConfiguration;

        public TokenManager(IOptions<JwtConfiguration> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public string GenerateToken(string issuer, string audience, string secretKey, double expirationMinutes, IEnumerable<Claim> claims = null)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateAccessToken(ApplicationUser user)
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "User")
            };

            return this.GenerateToken(
                _jwtConfiguration.Issuer,
                _jwtConfiguration.Audience,
                _jwtConfiguration.AccessTokenSecret,
                _jwtConfiguration.AccessTokenExpirationMinutes,
                claims);
        }

        public string GenerateRefreshToken()
        {
            return this.GenerateToken(
                _jwtConfiguration.Issuer,
                _jwtConfiguration.Audience,
                _jwtConfiguration.RefreshTokenSecret,
                _jwtConfiguration.RefreshTokenExpirationMinutes);
        }

        public bool ValidateRefreshToken(string refreshToken)
        {
            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.RefreshTokenSecret)),
                ValidIssuer = _jwtConfiguration.Issuer,
                ValidAudience = _jwtConfiguration.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                new JwtSecurityTokenHandler().ValidateToken(refreshToken, validationParameters, out var securityToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
