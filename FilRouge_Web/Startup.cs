using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilRouge_Web.Startup))]
namespace FilRouge_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
