using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(scaffef.Startup))]
namespace scaffef
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
