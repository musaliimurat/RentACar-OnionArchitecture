using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Security.JWT
{
    public interface ITokenValidation
    {
        ClaimsPrincipal ValidationToken(string token);
    }
}
