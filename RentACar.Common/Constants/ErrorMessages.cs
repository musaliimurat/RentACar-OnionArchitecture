using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Constants
{
    public static class ErrorMessages
    {
        public const string ValidationFailed = "Validation failed. Please check your inputs.";
        public const string CarAlreadyExists = "A car with this license plate already exists.";
        public const string Unauthorized = "You are not authorized to perform this action.";
        public const string Forbidden = "You do not have permission to access this resource.";
        public const string NotFound = "{0} with ID {1} was not found.";
    }
}
