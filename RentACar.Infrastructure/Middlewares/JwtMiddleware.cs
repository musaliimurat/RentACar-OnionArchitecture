using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RentACar.Application.Models;
using RentACar.Infrastructure.Security.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private TokenOptions _tokenOptions;

        public JwtMiddleware(TokenOptions tokenOptions, IConfiguration configuration, RequestDelegate next)
        {
            _configuration = configuration;
            _next = next;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Burada JWT doğrulama və istifadəçi məlumatlarını əldə etmək üçün kod əlavə edə bilərik
            // Məsələn, Authorization başlığını yoxlamaq və tokeni doğrulamaq
            // Əgər token doğrulanırsa, istifadəçi məlumatlarını HttpContext üzərində saxlayıriq
            // context.User = ...;
            // Sonrakı middleware-lərə keçid

            var accessToken = context.Request.Cookies["accessToken"];

            if (!string.IsNullOrEmpty(accessToken))
            {
                try
                {
                    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                    var key = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

                    var claimsPrincipal = tokenHandler.ValidateToken(accessToken, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
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
                    context.User = claimsPrincipal;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            await _next(context);
        }
    }
}
