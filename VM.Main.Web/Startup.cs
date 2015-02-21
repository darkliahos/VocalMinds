using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VM.Main.Web.Startup))]
namespace VM.Main.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
