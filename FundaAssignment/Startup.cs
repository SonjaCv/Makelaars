using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FundaAssignment.Startup))]
namespace FundaAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
