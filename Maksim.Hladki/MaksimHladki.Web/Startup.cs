using Microsoft.Owin;
using Owin;
using Startup = MaksimHladki.Web.Startup;

[assembly: OwinStartup(typeof (Startup))]

namespace MaksimHladki.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}