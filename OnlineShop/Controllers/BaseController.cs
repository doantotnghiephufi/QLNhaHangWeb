using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineShop.Common;

namespace OnlineShop.Controllers
{
    public class BaseController : Controller
    {
        public string SignInUrl { get; set; }
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (SessionUserBO)Session[CommonConstants._USER_SESSION];
            if(session ==null)
            {
                SignInUrl = "/trang-chu?continue=" + filterContext.HttpContext.Request.Url.ToString().TrimEnd('/');
                filterContext.HttpContext.Response.Redirect(SignInUrl, true);
                filterContext.Result = new RedirectResult(SignInUrl, true);
            }
            //else
            //{
            //    if(session.UserType != 0)
            //    {
            //        filterContext.Result = new RedirectResult("/trang-chu", true);
            //    }
            //}
            
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            filterContext.HttpContext.Response.SetCookie(new HttpCookie("RefreshFilter", filterContext.HttpContext.Request.Url.ToString()));
        }
    }
}