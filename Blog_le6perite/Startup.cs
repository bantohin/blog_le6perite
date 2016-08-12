using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blog_le6perite.Startup))]
namespace Blog_le6perite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
