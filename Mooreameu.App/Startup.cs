using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mooreameu.App.Startup))]
namespace Mooreameu.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
