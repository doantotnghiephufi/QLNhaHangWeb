using System.Web.Mvc;

namespace OnlineShop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "quan-ly-admin",
                "Admin/quan-ly-cua-admin",
                new { controller="Home",action = "Index" },
                new string[] { "OnlineShop.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "quan-ly-combo",
                "Admin/quan-ly-combo",
                new { controller = "Combo", action = "Index" },
                new string[] { "OnlineShop.Areas.Admin.Controllers" }
            );

            //Quản lý user
            context.MapRoute(
                "quan-ly-tai-khoan",
                "Admin/them-moi-nguoi-dung",
                new { controller = "User", action = "Index" },
                new string[] { "OnlineShop.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                 name: "ajax-admin",
                 url: "Admin/aj/{controller}/{action}/{*q}",
                 namespaces: new string[] { "OnlineShop.Areas.Admin.Controllers" }
              );
            context.MapRoute(
                "them-moi-mon-an",
                "Admin/mon-an/them-moi-mon-an",
                new { controller = "Food", action = "CreateFood" },
                new string[] { "OnlineShop.Areas.Admin.Controllers" }
            );
        }
    }
}