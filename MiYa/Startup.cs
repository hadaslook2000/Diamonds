using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiYa.Startup))]
namespace MiYa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
