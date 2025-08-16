using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentACar.Application.Models;
using RentACar.Infrastructure.Security.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Security.JWT
{
    public class ValidateToken : ITokenValidation
    {
        private readonly IConfiguration _configuration;
        private TokenOptions _tokenOptions;

        public ValidateToken(TokenOptions tokenOptions, IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        public ClaimsPrincipal ValidationToken(string token)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _tokenOptions.Issuer,
                    ValidAudience = _tokenOptions.Audience,
                    ValidateLifetime = true, // Tokenin vaxtı bitməsini yoxlamaq üçün
                    ClockSkew = TimeSpan.Zero // Tokenin vaxtı bitməsini dərhal yoxlamaq üçün
                }, out _);
                return claimsPrincipal;
                throw new SecurityTokenException("Invalid token");
            }
            catch (Exception)
            {
                throw new SecurityTokenException("Token validation failed");
            }
        }
    }
}
