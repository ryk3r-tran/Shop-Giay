using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "Product",
              url: "SanPham/{action}/{id}",
              defaults: new { controller = "SanPham", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Contact",
               url: "LienHe/{action}/{id}",
               defaults: new { controller = "LienHe", action = "LienHe", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Check",
               url: "KiemTraDonHang/{action}/{id}",
               defaults: new { controller = "KiemTraDonHang", action = "KiemTraDonHang", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Cart",
                url: "GioHang/{action}/{id}",
                defaults: new { controller = "GioHang", action = "GioHang", id = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "Blog",
                url: "Blog/{action}/{id}",
                defaults: new { controller = "Blog", action = "Blog", id = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "Default",
                url: "{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
