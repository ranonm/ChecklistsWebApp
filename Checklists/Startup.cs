using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Checklists.Startup))]
namespace Checklists
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
