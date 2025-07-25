using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RentACar.Infrastructure.IoC
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollections)
        {
            serviceCollections.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
