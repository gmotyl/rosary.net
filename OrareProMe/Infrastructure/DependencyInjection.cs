using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrareProMe.Infrastructure.Database;

namespace OrareProMe.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddDbContext<IApplicationDbContext, MysqlContext>(opt =>
                    opt.UseMySQL("Server=localhost;Port=3306;database=rosary;user=gomes;password=rosary")
                    .EnableSensitiveDataLogging()
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                );
            services.AddTransient<IntentionRepository>();

            return services;
        }
    }
}