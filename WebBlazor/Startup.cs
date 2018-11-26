using Blazor.Extensions;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace WebBlazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddNotifications();
            services.AddLoadingBar();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.UseLoadingBar();
            app.AddComponent<App>("app");
        }
    }
}
