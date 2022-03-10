using Dukkantek.Domain.Pontracts.Manager;
using Dukkantek.Managers.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.DI.Managers
{
    class ManagerModuleDependencyInjectionHandler
    {
        internal static void Handel(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.Add(new ServiceDescriptor(typeof(IProductManager), typeof(ProductManager), ServiceLifetime.Scoped));
        }
    }
}
