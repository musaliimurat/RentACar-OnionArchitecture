using Microsoft.Extensions.Configuration;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Models;
using RentACar.Domain.Entities.Concrete;
using RentACar.Infrastructure.Extensions;
using RentACar.Infrastructure.Security.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Security.JWT
{
    public class JwtHelper : ITokenHelperService
    {
        public IConfiguration Configuration { get; }
        private DateTime _expirationDate;
        private DateTime _expirationRefreshDate;
        private TokenOptions _tokenOptions;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions  = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateAccessToken(AppUser user, List<OperationClaim> operationClaims, List<RoleGroup> roleGroups)
        {
            _expirationDate = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, roleGroups, operationClaims);
            var jwtSecurityTokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var accessToken = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = accessToken,
                Expiration = _expirationDate
            };
        }

        public RefreshToken CreateRefreshToken(AppUser user)
        {
            var randomNumber = new byte[32];
            _expirationRefreshDate = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);
            string rawRefreshToken;
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                rawRefreshToken = Convert.ToBase64String(randomNumber);
            }

            return new RefreshToken
            {
                Expiration = _expirationRefreshDate,
                Token = rawRefreshToken,
                Created = DateTime.UtcNow,
            };
        }

        private System.IdentityModel.Tokens.Jwt.JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AppUser user, Microsoft.IdentityModel.Tokens.SigningCredentials signingCredentials, List<RoleGroup> roleGroups, List<OperationClaim> operationClaims)
        {
            var jwtSecurityToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken
                (
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    expires: _expirationDate,
                    notBefore: DateTime.UtcNow,
                    claims: SetClaims(user, roleGroups, operationClaims),
                    signingCredentials: signingCredentials
                );
            return jwtSecurityToken;
        }

        private IEnumerable<Claim> SetClaims(AppUser user, List<RoleGroup> roleGroups, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRolesAndOperations(roleGroups.Select(c => c.Name).ToArray(), operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
