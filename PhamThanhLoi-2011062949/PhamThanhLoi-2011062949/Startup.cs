using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhamThanhLoi_2011062949.Startup))]
namespace PhamThanhLoi_2011062949
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
