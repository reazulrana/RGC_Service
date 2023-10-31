using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RGC_Service.Startup))]
namespace RGC_Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
