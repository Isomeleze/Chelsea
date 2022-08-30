using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chelsea.uii.Startup))]
namespace Chelsea.uii
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
