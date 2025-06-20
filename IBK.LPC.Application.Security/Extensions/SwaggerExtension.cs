using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBK.LPC.Application.Security.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddServicesSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LPC API .Net",
                    Description = "Standart Authorization header using the Bearer scheme (\"bearer {token}\")",
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Name = HeaderNames.Authorization
                });

                options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        Array.Empty<string>()
                    }
                    }
                );
                string fileXml = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                if (File.Exists(fileXml)) options.IncludeXmlComments(fileXml);

            });
            return services;
        }
    }
}
