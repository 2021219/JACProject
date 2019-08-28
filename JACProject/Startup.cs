using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JACProject.Startup))]
namespace JACProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
