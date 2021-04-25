using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Rosary.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddCors(config =>
            {
                config.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("OrareProMe", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "OrareProMe API",
                    Version = "v1"
                });
            });

            return services;
        }
    }
}