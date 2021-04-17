using FluentValidation.AspNetCore;
using Infrastructure.Filters;
using Infrastructure.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Installers
{
    public class CoreInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddMvc(opt =>
                {
                    opt.EnableEndpointRouting = false;
                    opt.Filters.Add<ValidatorFilter>();
                })
                .AddFluentValidation(fv => 
                    fv.RegisterValidatorsFromAssemblyContaining<CoinCreateDtoValidator>());
        }
    }
}