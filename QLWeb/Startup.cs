using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(QLWeb.Startup))]

namespace QLWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Configuration(app);
        }
    }
}
