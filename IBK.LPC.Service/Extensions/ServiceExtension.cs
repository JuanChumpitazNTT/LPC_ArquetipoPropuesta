using System.Reflection;
using IBK.LPC.Application.Security.Extensions;

namespace IBK.LPC.Service.Extensions
{
    public static class ServiceExtension
    {
        public static WebApplicationBuilder AddWebApplication(this WebApplicationBuilder webApplicationBuilder, IConfiguration configuration)
        {

            return webApplicationBuilder;
        }
        public static IServiceCollection AddServicesApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServicesSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml"); //Swashbuckle swagger
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}
