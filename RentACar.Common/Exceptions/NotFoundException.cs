using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Exceptions
{
    public class NotFoundException(string entity, object key) : BaseException($"{entity} with key ({key}) was not found.")
    {
    }
}
