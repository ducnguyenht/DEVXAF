using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NAANCMS.Startup))]
namespace NAANCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
