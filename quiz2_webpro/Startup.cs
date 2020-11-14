using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(quiz2_webpro.Startup))]
namespace quiz2_webpro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
