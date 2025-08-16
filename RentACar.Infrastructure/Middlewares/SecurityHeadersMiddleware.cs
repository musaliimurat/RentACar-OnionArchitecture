using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Middlewares
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;
        public SecurityHeadersMiddleware(RequestDelegate next, IMemoryCache memoryCache)
        {
            _next = next;
            _memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;
            var headers = context.Response.Headers;

            // Swagger daxilində Content-Security-Policy qoymuruq ki, problem olmasın
            bool isSwagger = path.StartsWith("/swagger") || path.StartsWith("/index.html");

            headers.TryAdd("X-Content-Type-Options", "nosniff");
            headers.TryAdd("X-Frame-Options", "DENY");
            headers.TryAdd("X-XSS-Protection", "1; mode=block");
            headers.TryAdd("Referrer-Policy", "no-referrer");
            if (!isSwagger)
                headers.TryAdd("Content-Security-Policy", "default-src 'self'");



            // Server başlığını silmək (security by obscurity)
            headers.Remove("Server");
            headers.Remove("X-Powered-By");
            headers.Remove("X-AspNet-Version");
            headers.Remove("X-AspNetMvc-Version");

            await _next(context);
        }
    }
}
