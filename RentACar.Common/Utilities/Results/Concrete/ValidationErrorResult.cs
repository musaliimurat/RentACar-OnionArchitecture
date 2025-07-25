using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace RentACar.Common.Utilities.Results.Concrete
{
    public class ValidationErrorResult : Result
    {
        public List<ValidationFailure> Errors { get; }

        public ValidationErrorResult(List<ValidationFailure> errors, string message = "Validation failed") : base(false, message)
        {
            Errors = errors;
        }
    }
}
