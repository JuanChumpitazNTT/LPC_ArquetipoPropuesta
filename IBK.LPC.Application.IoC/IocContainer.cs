using IBK.LPC.Application.Interface;
using IBK.LPC.Application.Main;
using IBK.LPC.Infraestructure.Interface;
using IBK.LPC.Infraestructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBK.LPC.Application.IoC
{
    public static class IocContainer
    {
        public static IServiceCollection AddDependencyInjectionInterfaces(this IServiceCollection services)
        {
            services.AddDependencyInjectionApplication();
            services.AddDependencyInjectionRepository();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        private static IServiceCollection AddDependencyInjectionApplication(this IServiceCollection services)
        {
            services.AddScoped<IProveedorApplication, ProveedorApplication>();
            return services;
        }

        private static IServiceCollection AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IProveedorRepository, ProveedorRepository>();

            return services;
        }
    }
}
