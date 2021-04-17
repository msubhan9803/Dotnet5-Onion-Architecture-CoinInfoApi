using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Contracts;
using Service.Implementations;

namespace WebApi.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<ICoinService, CoinService>();
        }
    }
}