using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyOwnShop.WebUI.Startup))]
namespace MyOwnShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
