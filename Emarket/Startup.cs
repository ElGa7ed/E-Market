using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Emarket.Startup))]
namespace Emarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
