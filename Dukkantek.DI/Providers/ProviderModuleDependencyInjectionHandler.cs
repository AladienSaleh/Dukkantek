using Dukkantek.Data.AutoMappings;
using Dukkantek.Domain.Pontracts.Provider;
using Dukkantek.Providers.Products;
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
        }
    }
}
