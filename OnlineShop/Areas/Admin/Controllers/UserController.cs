using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreateUserAjax(string objAccount)
        {
            if (ModelState.IsValid)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                KhachHang objKhachHang = serializer.Deserialize<KhachHang>(objAccount);

                var daoKH = new KhachHangDAO();
                int result = daoKH.insertKhachHang(objKhachHang);
                if (result == 0)
                {
                    return Json(new { iserror = false, isExistUser = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (result > 0)
                        return Json(new { iserror = false, isExistUser = false }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                iserror=true
            },JsonRequestBehavior.AllowGet);
        }
    }
}