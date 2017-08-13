using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(policlinico__con_migracion.Startup))]
namespace policlinico__con_migracion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
