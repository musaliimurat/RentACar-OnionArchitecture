using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Common.Exceptions;

namespace RentACar.Application.Behaviors.Validation.FluentValidation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IHttpContextAccessor httpContextAccessor)
        {
            _validators = validators;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
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

                if (typeof(TResponse) == typeof(Utilities.Results.Abstract.IResult) || typeof(TResponse).GetInterfaces().Contains(typeof(Utilities.Results.Abstract.IResult)))
                {
                    var result = new ValidationErrorResult(failures);
                    return (TResponse)(object)result;
                }
            }

            return await next();
        }
    }


}
