using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace RentACar.Common.Exceptions
{
    public class CustomValidationException : BaseException
    {
        public IDictionary<string, string[]> Errors { get; }

        public CustomValidationException(IEnumerable<ValidationFailure> failures)
            : base("One or more validation errors occurred.")
        {
            Errors = failures
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
        }
    }
}
