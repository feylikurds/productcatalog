using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Product_Catalog.Startup))]
namespace Product_Catalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
