using FluentValidation;
using MediatR;
using RentACar.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Behaviors.Validation.FluentValidation
{
     public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<object>(request);
                var validationFailures = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

                var errors = validationFailures
                    .SelectMany(result => result.Errors)
                    .Where(error => error != null)
                    .ToList();

                if (errors.Any())
                {
                    throw new CustomValidationException(errors);
                }
            }
            
            return await next();
        }
    }

}
