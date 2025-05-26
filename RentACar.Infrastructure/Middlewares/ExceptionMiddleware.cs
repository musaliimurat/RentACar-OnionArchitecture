using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RentACar.Common.Exceptions;
using System.Text.Json;

namespace RentACar.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomValidationException ex)
            {
                _logger.LogWarning("Validation error: {Errors}", string.Join(", ", ex.Errors));

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 400;

                var response = new
                {
                    Message = "Validation Error",
                    Errors = ex.Errors
                };

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 500;

                var response = new { Message = "An unexpected error occurred. Please try again later." };
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }

}

