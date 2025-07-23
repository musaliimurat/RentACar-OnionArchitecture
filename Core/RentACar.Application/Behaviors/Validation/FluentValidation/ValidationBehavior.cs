using FluentValidation;
using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Common.Attributes;
using RentACar.Common.Exceptions;

namespace RentACar.Application.Behaviors.Validation.FluentValidation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            _validators = validators;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Yalnız WithValidationAttribute varsa, yoxla
            var isValidationRequired = request.GetType()
                .GetCustomAttributes(typeof(WithValidationAttribute), true)
                .Any();

            if (!isValidationRequired)
                return await next(); // Validation olmadan keç

            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                var path = _httpContextAccessor.HttpContext?.Request.Path.Value;

                if (!string.IsNullOrEmpty(path) && path.StartsWith("/api"))
                    throw new CustomValidationException(failures);

                var resultType = typeof(TResponse).IsGenericType ? typeof(TResponse).GetGenericArguments()[0] : typeof(TResponse);

                if (typeof(IResult).IsAssignableFrom(resultType))
                {
                    return (TResponse)(object)new ValidationErrorResult(failures);
                }
            }

            return await next();
        }
    }


}
