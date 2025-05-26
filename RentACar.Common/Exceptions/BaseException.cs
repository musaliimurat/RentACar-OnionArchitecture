using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Exceptions
{
    public abstract class BaseException : Exception
    {
            protected BaseException(string message) : base(message)
            {
            }
    }
}
