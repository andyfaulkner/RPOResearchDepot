﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RPOResearchDepot.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    Controller = "Product",
                    Action = "Index",
                    category = (string)null, page = 1
                }
            );

            routes.MapRoute(null,
                "Page{page}",
                new
                {
                    Controller = "Product",
                    Action = "List",
                    category = (string)null
                },
                    new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{category}",
                new
                {
                    Controller = "Product",
                    Action = "List",
                    page = 1
                }
            );

            routes.MapRoute(null,
               "{category}/Page{page}",
               new
               {
                   Controller = "Product",
                   Action = "List"
               },
                   new { page = @"\d+" }
           );

            routes.MapRoute(null,
                "{controller}/{action}");
        }
    }
}
