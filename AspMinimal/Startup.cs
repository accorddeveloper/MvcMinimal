using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AspMinimal.Startup))]

namespace AspMinimal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
