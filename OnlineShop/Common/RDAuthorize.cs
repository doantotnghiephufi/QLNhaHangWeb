using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Common
{
    public class RDAuthorize: ActionFilterAttribute
    {
        public static string Username
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[Common.CommonConstants._USER_SESSION]);
            }
        }
        public string SignInUrl { get; set; }
        // GET: Base
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (SessionUserBO)HttpContext.Current.Session[CommonConstants._USER_SESSION];
            if (session == null)
            {
                SignInUrl = "/dang-nhap?continue=" + filterContext.HttpContext.Request.Url.ToString().TrimEnd('/');
                filterContext.HttpContext.Response.Redirect(SignInUrl, true);
                filterContext.Result = new RedirectResult(SignInUrl, true);
            }
           
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            filterContext.HttpContext.Response.SetCookie(new HttpCookie("RefreshFilter", filterContext.HttpContext.Request.Url.ToString()));
        }
    }
}