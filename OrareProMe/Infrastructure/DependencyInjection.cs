using Microsoft.Extensions.DependencyInjection;
using OrareProMe.Infrastructure.Database;

namespace OrareProMe.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            string connectionString = "Server=localhost;Port=3306;database=rosary;user=gomes;password=rosary";
            services.AddScoped<IApplicationDbContext, MysqlContext>(_ => new MysqlContext(connectionString, true));
            services.AddTransient<IntentionRepository>();

            return services;
        }
    }
}