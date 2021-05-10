using Microsoft.Extensions.DependencyInjection;

namespace OrareProMe.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services
                .AddSingleton<IntentionRepository>();

            return services;
        }
    }
}