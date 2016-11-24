using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NAANSolution_ReactJS.Startup))]
namespace NAANSolution_ReactJS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
