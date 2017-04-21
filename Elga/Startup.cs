using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Elga.Startup))]
namespace Elga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
