using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Installers;

namespace WebApi.Extensions
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssmebly<TStartup>(this IServiceCollection services, IConfiguration Configuration) 
            where TStartup : class
        {
            var installers = typeof(TStartup).Assembly.ExportedTypes.Where(x => 
                    typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, Configuration));
        }
    }
}