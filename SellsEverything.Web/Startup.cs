using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SellsEverything.Web.Startup))]
namespace SellsEverything.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
