using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EPS.Startup))]
namespace EPS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
