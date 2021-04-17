using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace WebApi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        configuration["ConnectionStrings:DefaultConnection"],
                        new MySqlServerVersion(new Version(8, 0, 23)),
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend))
                    .EnableSensitiveDataLogging()
            );
        }
    }
}