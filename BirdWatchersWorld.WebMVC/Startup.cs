using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BirdWatchersWorld.WebMVC.Startup))]
namespace BirdWatchersWorld.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
