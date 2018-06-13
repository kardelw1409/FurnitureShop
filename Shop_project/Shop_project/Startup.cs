using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shop_project.Startup))]
namespace Shop_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
