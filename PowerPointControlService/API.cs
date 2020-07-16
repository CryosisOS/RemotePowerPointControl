using Owin;
using System.Web.Http;

namespace PowerPointControlService {
    class API {
        public void Configuration(IAppBuilder appBuilder) {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new {}
            );
            appBuilder.UseWebApi(config);
        }
    }
}
