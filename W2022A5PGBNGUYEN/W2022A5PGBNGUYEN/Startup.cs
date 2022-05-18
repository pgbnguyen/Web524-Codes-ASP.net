using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(W2022A5PGBNGUYEN.Startup))]

namespace W2022A5PGBNGUYEN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
