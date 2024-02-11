using FluentValidation.AspNetCore;
using Jazani.Application.Admins.Services;
using Jazani.Application.Admins.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jazani.Application.Cores.Contexts
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services)
        {
            //automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            //Application
            //services.AddTransient<IAreaTypeService, AreaTypeService>();
            // FluentValidation
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            return services;
        }
    }
}
