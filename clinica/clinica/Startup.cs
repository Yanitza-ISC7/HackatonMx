using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(clinica.Startup))]
namespace clinica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
