using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Extensions
{
    public static class ClaimPrincipialExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal principal, string claimType)
        {
            var claims = principal.FindAll(claimType).Select(x=>x.Value).ToList();
            return claims;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal principal)
        {
            return principal.Claims(ClaimTypes.Role);
        }
    }
}
