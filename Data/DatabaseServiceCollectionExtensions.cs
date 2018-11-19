using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;

namespace Data
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabasePushSubscriptionStore(this IServiceCollection services, IConfiguration configuration)
        {
            
            var sqlConnectionString = configuration.GetConnectionString("WebsiteDB");
            services.AddEntityFrameworkSqlServer().AddDbContext<WebsiteDbContext>(options => options.UseNpgsql(sqlConnectionString, o =>
            {
                o.MigrationsAssembly("Data");
            }));

            services.AddTransient<IPushSubscriptionStore, DatabasePushSubscriptionStore>();

            return services;
        }
    }
}
