using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DatabaseApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebsiteDbContext(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<WebsiteDbContext>();
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }

            return app;
        }
    }
}
