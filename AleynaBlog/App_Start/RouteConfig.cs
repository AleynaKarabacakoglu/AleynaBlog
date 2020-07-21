using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AleynaBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "About",
               url: "hakkimda",
               defaults: new { controller = "About", action = "Index" }
           );

            routes.MapRoute(
               name: "Blog",
               url: "blog",
               defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Contact",
              url: "Iletisim",
              defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
