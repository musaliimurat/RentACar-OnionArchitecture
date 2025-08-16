using RentACar.Common.Constants;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRolesAndOperations(this ICollection<Claim> claims, string[] roles, string[] operationClaims)
        {
           if(roles !=null)
                foreach(var role in roles) 
                    claims.Add(new Claim(ClaimTypes.Role, role));

            if (operationClaims != null)
                foreach (var operationClaim in operationClaims) 
                    claims.Add(new Claim(ClaimTypesCustom.OperationClaim, operationClaim));
        }

      
    }
}
