using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vendoki.Web.Startup))]
namespace Vendoki.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
