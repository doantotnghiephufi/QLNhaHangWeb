using Models.DAO;
using Models.EF;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Common;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        NhaHangDbContext db = new NhaHangDbContext();
        // GET: Account
        [HttpPost]
        public ActionResult Login(string userName,string passWord)
        {
            if (ModelState.IsValid)
            {
                string url = "";
                if (string.IsNullOrWhiteSpace(Request.UrlReferrer.Query) == false)
                {
                    url = Request.UrlReferrer.Query.Replace("?continue=", "");
                }
                if (string.IsNullOrEmpty(url))
                {
                    url = Request.Url.Scheme + "://" + Request.Url.Host;
                    if (Request.Url.Port != 80)
                        url += ":" + Request.Url.Port;
                    url += Request.UrlReferrer.LocalPath;
                }
                var dao = new UserDAO();
                var result = dao.Login(userName, Encryptor.MD5Hash(passWord));
                if(result==1)
                {

                    var userSession = new SessionUserBO();
                    KhachHang objKhachHang = dao.getAccountByEmail(userName);
                    if(objKhachHang !=null)
                    {
                        userSession.UserID = objKhachHang.MaKH;
                        userSession.Name = objKhachHang.TenKH;
                        userSession.PhoneNumber = objKhachHang.SDT;
                        userSession.Address = objKhachHang.DiaChiKH;
                        userSession.CMND = objKhachHang.CMND;
                        userSession.CreatedDate = objKhachHang.NgayTaoTT;
                    }
                    Session.Add(CommonConstants._USER_SESSION, userSession);
                    return Json(new { bolIsLogin = true ,url=url});
                }
                else
                {
                    string message = string.Empty;
                    if (result == -1)
                    {
                        message = "Tài khoản bị khóa. Vui lòng kiểm tra lại!";
                    }
                    else if (result == 0)
                        message = "Tài khoản không tồn tại. Vui lòng kiểm tra lại!";
                    else if (result == 2)
                        message = "Sai mật khẩu. Vui lòng kiểm tra lại!";
                    return Json(new { bolIsLogin = false, url = url,messageError = message});
                }

            }
            return Json(new { });
        }
        public ActionResult Register()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.UrlReferrer !=null)
                {
                    SessionUserBO session = (SessionUserBO)Session[CommonConstants._USER_SESSION];
                    if (session != null) //nếu đã login thì không được vào trang đăng ký (trường hợp coppy link)
                        return Redirect("/");
                    string url = "";
                    if (string.IsNullOrWhiteSpace(Request.UrlReferrer.Query) == false)
                    {
                        url = Request.UrlReferrer.Query.Replace("?continue=", "");
                    }
                    if (string.IsNullOrEmpty(url))
                    {
                        url = Request.Url.Scheme + "://" + Request.Url.Host;
                        if (Request.Url.Port != 80)
                            url += ":" + Request.Url.Port;
                        url += Request.UrlReferrer.LocalPath;
                    }
                    ViewBag.URL = url;
                    return View();
                }
                return Redirect("/Trang-chu");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(KhachHangModel model,string hdUrlReferrer)
        {
            if(ModelState.IsValid)
            {
                
                KhachHangDAO dao = new KhachHangDAO();
                if (dao.isExistSDT(model.SDT))
                {
                    ModelState.AddModelError("", "Số điện thoại đã tồn tại!");
                }
                else if(dao.isExistEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại!");
                }
                else
                {
                   
                    var objKhachhang = new KhachHang();
                    string lastID = dao.getLastID();
                    objKhachhang.MaKH = Common.XuLy.NextID(lastID, "KH");
                    objKhachhang.TenKH = model.TenKH;
                    objKhachhang.SDT = model.SDT;
                    objKhachhang.CMND = model.CMND;
                    objKhachhang.DiaChiKH = model.DiaChiKH;
                    objKhachhang.PASSWORD = Common.Encryptor.MD5Hash(model.PassWord);
                    objKhachhang.Email = model.Email;
                    DateTime dt = DateTime.Now;
                    objKhachhang.Activation = Common.Encryptor.MD5Hash(model.Email+dt.ToString());
                    objKhachhang.NgayTaoTT = DateTime.Now;
                    int result = dao.insertKhachHang(objKhachhang);
                    if (result == 1)
                    {
                        ViewBag.Success = "success";
                        SessionUserBO session = new SessionUserBO();
                        session.UserID = objKhachhang.MaKH;
                        session.Name = objKhachhang.TenKH;
                        session.PhoneNumber = objKhachhang.SDT;
                        session.Email = objKhachhang.Email;
                        session.Address = objKhachhang.DiaChiKH;
                        session.CMND = objKhachhang.CMND;
                        session.CreatedDate = objKhachhang.NgayTaoTT;
                        
                        ViewBag.URL = hdUrlReferrer;
                        model = new KhachHangModel();
                        BuildEmailTemplate(objKhachhang.MaKH);
                        //string content = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
                        //content = content.Replace("{{Name}}", objKhachhang.TenKH);

                        //new MailHelper().SendMail(objKhachhang.Email, "Kích Hoạt Tài Khoản", content);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View();
        }
        public ActionResult Confirm(string MaKH,string Activation)
        {
            ViewBag.MaKH = MaKH;
            ViewBag.Activation = Activation;
            return View();
        }
        public JsonResult RegisterConfirm(string MaKH, string Activation)
        {
            var msg = "";
            KhachHang objKh = db.KhachHangs.Where(t => t.MaKH == MaKH).FirstOrDefault();
            if(objKh != null)
            {
                try
                {
                    
                    objKh.isValid = true;
                    db.SaveChanges();
                    msg = "Tài khoản của bạn đã được kích hoạt!";
                }
                catch 
                {
                    msg = "Kích hoạt tài khoản không thành công. Vui lòng kiểm tra lại!";
                }
                
            }
            else
            {
                msg = "Lỗi hệ thống";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public void BuildEmailTemplate(string maKH)
        {
            string content = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
            var regInfo = new KhachHangDAO().getKhachhangByID(maKH);
            var url = "http://nhahangmvc.com/Xac-nhan-tai-khoan/"+regInfo.MaKH+"/" + regInfo.Activation;
            content = content.Replace("{{Name}}", regInfo.TenKH);
            content = content.Replace("@ViewBag.ConfirmationLink", url);
            new MailHelper().SendMail(regInfo.Email, "Kích Hoạt Tài Khoản", content);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants._USER_SESSION] = null;

            return Redirect("/");
        }

    }
}