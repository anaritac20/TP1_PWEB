using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TP1.Startup))]
namespace TP1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
