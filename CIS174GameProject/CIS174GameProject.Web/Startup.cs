using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS174GameProject.Startup))]
namespace CIS174GameProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
