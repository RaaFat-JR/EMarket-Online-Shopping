using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMarket.Startup))]
namespace EMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
