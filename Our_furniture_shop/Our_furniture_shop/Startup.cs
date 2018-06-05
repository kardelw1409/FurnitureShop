using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Our_furniture_shop.Startup))]
namespace Our_furniture_shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
