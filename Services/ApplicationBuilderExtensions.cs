using Data;
using Microsoft.AspNetCore.Builder;

namespace Services
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePushSubscriptionStore(this IApplicationBuilder app)
        {
            app.UseWebsiteDbContext();

            return app;
        }
    }
}
