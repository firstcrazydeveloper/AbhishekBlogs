using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AbhishekBlogs
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Home",
               "{controller}/{action}.html/{id}/{typename}",
                new { controller = "Home", action = "BlogView", typename = UrlParameter.Optional },
                new { id = @"^\d+$" }
           );
           // routes.MapRoute(
           //    "Blog",
           //    "{controller}/{action}/{id}/{typename}.html",
           //     new { controller = "Blogs", action = "BlogView", typename = UrlParameter.Optional },
           //     new { id = @"^\d+$" }
           //);
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{typename}",
               defaults: new { controller = "Home", action = "Bloglist", typename = UrlParameter.Optional }
           );
           // routes.MapRoute(
           //   name: "Test",
           //    url: "Blog/Bloglist/{typename}",
           //    defaults: new { controller = "Home", action = "Bloglist", typename = UrlParameter.Optional }
           //);
        }
    }
}
