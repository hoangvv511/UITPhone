using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLWeb.Startup))]
namespace QLWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configuration(app);
        }
    }
}