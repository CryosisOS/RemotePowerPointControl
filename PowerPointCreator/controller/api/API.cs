using Microsoft.Owin.Hosting;
using Owin;
using System.Web.Http;

namespace PowerPointCreator
{
    public class API
    {
        public static void Register()
        {
            string baseAddress = "http://localhost:18200/";
            WebApp.Start<API>(url: baseAddress);
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { }
            );
            appBuilder.UseWebApi(config);
        }
    }
}
