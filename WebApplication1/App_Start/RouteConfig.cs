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
                name: "Admin",
                url: "Admin/{action}/{id}",
                defaults: new { controller = "Admin", action = "DieuKhien", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Account",
                url: "TaiKhoan/{action}/{id}",
                defaults: new { controller = "TaiKhoan", action = "DangNhap", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product",
                url: "SanPham/{action}/{id}",
                defaults: new { controller = "SanPham", action = "DaSachSanPham", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Contact",
                url: "LienHe/{action}/{id}",
                defaults: new { controller = "LienHe", action = "LienHe", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CheckOrder",
                url: "KiemTraDonHang/{action}/{id}",
                defaults: new { controller = "KiemTraDonHang", action = "KiemTraDonHang", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Blog",
                url: "Blog/{action}/{id}",
                defaults: new { controller = "Blog", action = "Blog", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Cart",
                url: "GioHang/{action}/{id}",
                defaults: new { controller = "GioHang", action = "GioHang", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
