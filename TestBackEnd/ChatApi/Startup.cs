using ChatApi;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace ChatApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var config = new HubConfiguration();
            config.EnableDetailedErrors = true;
            config.EnableJSONP = true;
            app.MapSignalR(config);
        }
    }
}
