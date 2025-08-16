using Microsoft.AspNetCore.Http;
using RentACar.Common.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Common.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using RentACar.Common.Constants;
using System.Security.Claims;
using RentACar.Common.Exceptions;

namespace RentACar.Common.Aspects.AuthAspect
{
   
    public class SecuredAspect : MethodInterception
    {
        private readonly string[] _requiredRoles;
        private readonly string[] _requiredPermissions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredAspect(string roles, string permissions)
        {
            _requiredRoles = (roles ?? string.Empty)
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            _requiredPermissions = (permissions ?? string.Empty)
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var user = _httpContextAccessor.HttpContext?.User
                       ?? throw new AuthorizationException("Kontekst yoxdur (HttpContext).");

            if (user.Identity?.IsAuthenticated != true)
                throw new AuthorizationException("Giriş tələb olunur.");

            // İstifadəçinin rolları və permission-ları
            var userRoles = user.FindAll(ClaimTypes.Role)
                                .Select(c => c.Value)
                                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var userPerms = user.FindAll(ClaimTypesCustom.OperationClaim)
                                .Select(c => c.Value)
                                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            // Heç bir tələb yoxdursa, burax
            if (_requiredRoles.Length == 0 && _requiredPermissions.Length == 0) return;

            // OR məntiqi: (istənilən tələb ödənərsə keçsin)
            bool pass =
                (_requiredRoles.Length > 0 && _requiredRoles.Any(r => userRoles.Contains(r))) ||
                (_requiredPermissions.Length > 0 && _requiredPermissions.Any(p => userPerms.Contains(p)));

            if (!pass)
                throw new AuthorizationException("Yetkiniz yoxdur!");
        }
    }
}
