using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(thanhloi_2011062949.Startup))]
namespace thanhloi_2011062949
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
