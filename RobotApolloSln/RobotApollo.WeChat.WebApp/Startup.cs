using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RobotApollo.WeChat.WebApp.Startup))]
namespace RobotApollo.WeChat.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
