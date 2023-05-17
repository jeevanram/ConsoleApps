using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AzureB2C_WebApp_ASP.NETFramework_MVC.Startup))]

namespace AzureB2C_WebApp_ASP.NETFramework_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}