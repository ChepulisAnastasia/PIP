using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksLibrary.Startup))]
namespace BooksLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
