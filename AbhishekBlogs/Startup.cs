using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbhishekBlogs.Startup))]
namespace AbhishekBlogs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
