using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoT4.Startup))]
namespace ProyectoT4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
