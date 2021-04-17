using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contracts;
using Persistence.Implementations;

namespace WebApi.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICoinRepository, CoinRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}