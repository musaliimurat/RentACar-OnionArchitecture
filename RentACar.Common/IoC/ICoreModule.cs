using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace RentACar.Common.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollections);
    }
}
