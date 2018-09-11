using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Agility.Web;
using Agility.Web.RestApi;

namespace Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.svc/{*pathInfo}");

            //Agility REST API Route
            routes.AddAgilityApiRoutes("api");

            //Agility Wildcard Route for Default Page Routing
            routes.MapRoute("Agility", "{*sitemapPath}", new { controller = "Agility", action = "RenderPage" },
                new { isAgilityPath = new Agility.Web.Mvc.AgilityRouteConstraint() });

            //Fallback Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}