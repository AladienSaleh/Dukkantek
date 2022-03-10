using Dukkantek.Domain.Pontracts.Manager;
using Dukkantek.Managers.Product;
using Dukkantek.Shared.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Dukkantek.Managers.UnitOfWork;

namespace Dukkantek.DI.Managers
{
    class ManagerModuleDependencyInjectionHandler
    {
        internal static void Handel(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.Add(new ServiceDescriptor(typeof(IProductManager), typeof(ProductManager), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUnitOfWorkManager), typeof(UnitOfWorkManager), ServiceLifetime.Scoped));
        }
    }
}
