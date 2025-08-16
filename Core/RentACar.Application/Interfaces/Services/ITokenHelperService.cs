using RentACar.Application.Models;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface ITokenHelperService
    {
        AccessToken CreateAccessToken(AppUser user, List<OperationClaim> operationClaims, List<RoleGroup> roleGroups);
        RefreshToken CreateRefreshToken(AppUser user);
    }
}
