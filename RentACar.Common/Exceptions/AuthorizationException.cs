using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Exceptions
{
    public class AuthorizationException : BaseException
    {
        public AuthorizationException(string message) : base(message) { }
    }
}
