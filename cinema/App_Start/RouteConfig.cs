﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cinema
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Gallery",
                url: "",
                defaults: new { controller = "Home", action = "Gallery", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin Manage Movies",
                url: "Admin/ManageMovies",
                defaults: new { controller = "Admin", action = "Movies", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin Edit Price",
                url: "Admin/ManageMovies/EditPrice/{movieObj}/{price}",
                defaults: new { controller = "Admin", action = "EditPrice"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
