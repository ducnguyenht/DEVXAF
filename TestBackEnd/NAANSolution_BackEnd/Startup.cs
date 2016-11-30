using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NAANSolution_BackEnd.Startup))]
namespace NAANSolution_BackEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
