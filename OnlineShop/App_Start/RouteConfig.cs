using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "ajax-default",
                url: "aj/{controller}/{action}/{*q}",
                namespaces: new string[] { "OnlineShop.Controllers" }
             );

            routes.MapRoute(
                name: "Dang-Ky",
                url: "Dang-Ky",
                defaults: new { controller = "Account", action = "Register" },
                namespaces: new string[] { "OnlineShop.Controllers" }

            );
            routes.MapRoute(
                name: "Xac-nhan-tai-khoan",
                url: "Xac-nhan-tai-khoan/{MaKH}/{Activation}",
                defaults: new { controller = "Account", action = "Confirm", MaKH = UrlParameter.Optional,Activation = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }

            );
            routes.MapRoute(
                name: "thong-tin-tai-khoan",
                url: "thong-tin-tai-khoan",
                defaults: new { controller = "User", action = "DetailUser" },
                namespaces: new string[] { "OnlineShop.Controllers" }

            );
            routes.MapRoute(
                name: "LogOut",
                url: "LogOut",
                defaults: new { controller = "Account", action = "Logout" },
                namespaces: new string[] { "OnlineShop.Controllers" }

            );
           
            routes.MapRoute(
                name: "Trang-Chu",
                url: "Trang-Chu",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
               name: "Dat-Ban",
               url: "Dat-Ban",
               defaults: new { controller = "User", action = "Booking" },
               namespaces: new string[] { "OnlineShop.Controllers" }
           );
            routes.MapRoute(
               name: "dang-nhap",
               url: "dang-nhap",
               defaults: new { controller = "Home", action = "Index" },
               namespaces: new string[] { "OnlineShop.Controllers" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
                
            );
            
        }
    }
}
