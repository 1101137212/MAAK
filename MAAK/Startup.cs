using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MAAK.Startup))]
namespace MAAK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
