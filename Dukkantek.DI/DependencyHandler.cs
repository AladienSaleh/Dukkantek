using Dukkantek.Data.Models;
using Dukkantek.DI.Managers;
using Dukkantek.DI.Providers;
using Dukkantek.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dukkantek.DI
{
    public class DependencyHandler
    {
        public static void Handel(IServiceCollection services, IConfiguration configuration)
        {
            DbContextOptionsBuilder MsSQL(DbContextOptionsBuilder builder) =>
                builder.UseSqlServer(configuration.GetConnectionString(DbContextNames.AuthenticationContext), sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(300);
                    sqlServerOptions.MinBatchSize(1).MaxBatchSize(1000);
                    sqlServerOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);

                });

            services.AddEntityFrameworkSqlServer().AddDbContext<DukkantekApiDbContext>(options => MsSQL(options));

            ProviderModuleDependencyInjectionHandler.Handel(services, configuration);

            ManagerModuleDependencyInjectionHandler.Handel(services, configuration);
        }

        
    }
}
