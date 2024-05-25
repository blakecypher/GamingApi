using GamingApi.GamingService;
using Infrastructure;

namespace Yld.GamingApi.WebApi;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDefaultServices();
        services.AddScoped<IGamingService, GamingService>();
        services.AddScoped<IMapseterMapper, MapsterMapping>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseDefaultAppConfig();
    }
}
