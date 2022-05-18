using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(W2022A6PGBNGUYEN.Startup))]

namespace W2022A6PGBNGUYEN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
