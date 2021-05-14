using Microsoft.Extensions.DependencyInjection;
using OrareProMe.Infrastructure.Database;

namespace OrareProMe.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var contextFactory = new MySQLContextFactory();
            services.AddScoped<IApplicationDbContext, MysqlContext>(_ => contextFactory.CreateDbContext(null));
            services.AddTransient<IntentionRepository>();

            return services;
        }
    }
}