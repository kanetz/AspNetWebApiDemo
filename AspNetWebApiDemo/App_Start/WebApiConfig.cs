using System.Web.Http;

namespace AspNetWebApiDemo
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            ConfigureHttpRoutes(configuration.Routes);
        }

        private static void ConfigureHttpRoutes(HttpRouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "Courses",
                routeTemplate: "",
                defaults: new { controller = "Courses" }
                );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}