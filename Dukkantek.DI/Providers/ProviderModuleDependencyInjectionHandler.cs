using Dukkantek.Data.AutoMappings;
using Dukkantek.Domain.Contracts.Provider;
using Dukkantek.Domain.Pontracts.Provider;
using Dukkantek.Providers.Products;
using Dukkantek.Providers.UnitOfWork;
using Microsoft.Extensions.DependencyInjection; 

namespace Dukkantek.DI.Providers
{
    class ProviderModuleDependencyInjectionHandler
    {
        internal static void Handel(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ProductMapProfile));
            services.AddAutoMapper(typeof(CategoryMapProfile));

            services.Add(new ServiceDescriptor(typeof(IProductProvider), typeof(ProductProvider), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUnitOfWorkProvider), typeof(UnitOfWorkProvider), ServiceLifetime.Scoped));
        }
    }
}
