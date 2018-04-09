using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RigoAccounts.Startup))]
namespace RigoAccounts
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
