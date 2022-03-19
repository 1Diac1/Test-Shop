using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Test_Shop.Domain.Entities;
using Test_Shop.Domain.Settings;

namespace Test_Shop.Infrastructure.Identity.Services
{
    public class TokenManager
    {
        private readonly JwtConfiguration _jwtConfiguration;

        public TokenManager(IOptions<JwtConfiguration> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public string GenerateToken(JwtConfiguration jwtConfiguration, string secretKey, double expirationMinutes, IEnumerable<Claim> claims = null)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateAccessToken(User user)
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "User")
            };

            return this.GenerateToken(
                _jwtConfiguration,
                _jwtConfiguration.AccessTokenSecret,
                _jwtConfiguration.AccessTokenExpirationMinutes,
                claims);
        }

        public string GenerateRefreshToken()
        {
            return this.GenerateToken(
                _jwtConfiguration,
                _jwtConfiguration.RefreshTokenSecret,
                _jwtConfiguration.RefreshTokenExpirationMinutes);
        }

        public bool ValidateRefreshToken(string refreshToken)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters
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
                new JwtSecurityTokenHandler().ValidateToken(refreshToken, validationParameters, out SecurityToken securityToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
