using Dukkantek.DI.Managers;
using Dukkantek.DI.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dukkantek.DI
{
    public class DependencyHandler
    {
        public static void Handel(IServiceCollection services)
        {
            ProviderModuleDependencyInjectionHandler.Handel(services);
            ManagerModuleDependencyInjectionHandler.Handel(services);
        }
    }
}
