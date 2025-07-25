using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using RentACar.Common.Exceptions;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Common.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        public static IResult? Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                string? path = _httpContextAccessor?.HttpContext?.Request?.Path.Value;

                if (!string.IsNullOrEmpty(path) && path.StartsWith("/api", StringComparison.OrdinalIgnoreCase))
                {
                    throw new CustomValidationException(result.Errors);
                }

                // MVC üçün Result olaraq qaytar
                return new ValidationErrorResult(result.Errors);
            }

            return null;
        }
    }
}
