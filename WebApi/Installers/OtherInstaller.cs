using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebApi.Installers
 {
     public class OtherInstaller : IInstaller
     {
         public void InstallServices(IServiceCollection services, IConfiguration configuration)
         {
             services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApi", Version = "v1"}); });
             services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
         }
     }
 }