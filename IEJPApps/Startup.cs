using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IEJPApps.Startup))]
namespace IEJPApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
