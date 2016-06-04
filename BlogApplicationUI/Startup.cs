using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogApplicationUI.Startup))]
namespace BlogApplicationUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
