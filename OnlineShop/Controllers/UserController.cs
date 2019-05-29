using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;
using System.Globalization;
using System.Text;
using System.Web.Hosting;
using Common;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult DetailUser()
        {
            SessionUserBO session = (SessionUserBO)Session[CommonConstants._USER_SESSION];
            KhachHang objKhachhang = new KhachHang();
            if(session != null)
            {
                objKhachhang = new KhachHangDAO().getKhachhangByID(session.UserID);
                if(objKhachhang == null)
                {
                    Session.Remove(CommonConstants._USER_SESSION);
                    return Redirect("/");
                }
                return View(objKhachhang);
            }
            return Redirect("/");
        }

        public PartialViewResult ComboMonAn()
        {
            return PartialView();
        }
        public ActionResult Booking()
        {
            List<LoaiKhuVuc> listLoaiKV = new KhuVucDAO().layDsLoaiKhuVuc();
            ViewBag.HTMLcboLoaiKhuVuc = genHTMLCboLoaiKV(listLoaiKV);
            var SessionUser = new OnlineShop.Common.SessionUserBO();
            SessionUser = (SessionUserBO)Session[Common.CommonConstants._USER_SESSION];
            if(SessionUser !=null)
            {
                ViewBag.UserName = SessionUser.Name;
                ViewBag.MaKH = SessionUser.UserID;
            }
            return View();
        }

        private string genHTMLCboLoaiKV(List<LoaiKhuVuc> listLoaiKV)
        {
            StringBuilder sb = new StringBuilder();
            if (listLoaiKV.Count > 0 && listLoaiKV != null)
            {
                foreach (LoaiKhuVuc item in listLoaiKV)
                {
                    sb.Append(@"<option value='" + item.MaLoaiKhuVuc + "'>"  +item.TenLoaiKhuVuc + "</option>");
                }
            }
            return sb.ToString();
        }
        
        [HttpPost]
        public JsonResult LoadVitriAjax(string MaKhuVuc, string NgayDen,string GioDen)
        {
            string dateString = NgayDen + " " + GioDen + ":00";
            DateTime dateValue = DateTime.Parse(dateString, new CultureInfo("fr-FR", false));
            List<string> listphieudb = new ViTriDAO().layPhieuDatBan(DateTime.Now,dateValue);
            List<ViTri> listVitri = new ViTriDAO().LayDSViTriConTrong(MaKhuVuc, DateTime.Now, dateValue);

            string strHTMLCboVitri = GenHTMLCboVitri(listVitri);
            return Json(strHTMLCboVitri, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LoadKhuVucAjax(string maLoaiKV,int SLNguoi)
        {
            List<KhuVuc> listKhuVuc = new KhuVucDAO().layDSKhuVucTheoLoaiKV(maLoaiKV, SLNguoi);
            string strHTMLCboVitri = GenHTMLCboKhuVuc(listKhuVuc);
            return Json(strHTMLCboVitri, JsonRequestBehavior.AllowGet);
        }

        private string GenHTMLCboKhuVuc(List<KhuVuc> listKhuVuc)
        {
            StringBuilder sb = new StringBuilder();
            if (listKhuVuc.Count > 0 && listKhuVuc != null)
            {
                sb.Append(@"<option value=' - 1'>-- Chọn khu vực --</option>");
                foreach (KhuVuc item in listKhuVuc)
                {
                    sb.Append(@"<option value='" + item.MaKhuVuc + "'>" + item.TenKhuVuc + "</option>");
                }
            }
            return sb.ToString();
        }

        private string GenHTMLCboVitri(List<ViTri> listVitri)
        {
            StringBuilder sb = new StringBuilder();
            if (listVitri.Count > 0 && listVitri != null)
            {
                sb.Append(@"<option value=' - 1'>-- Chọn khu vực --</option>");
                foreach (ViTri item in listVitri)
                {
                    sb.Append(@"<option value='" + item.MaViTri + "'>" + item.TenViTri + "</option>");
                }
            }
            return sb.ToString();
        }

        [RDAuthorize]
        [HttpPost]
        public JsonResult BookingAjax(int SLnguoi, string NgayDen, string GioDen,string maVitri)
        {
            SessionUserBO session = (SessionUserBO)Session[CommonConstants._USER_SESSION];
            var phieuDatBanDAO = new PhieuDatBanDAO();
            PhieuDatBan phieuDatBan = new PhieuDatBan();
            string lastID = phieuDatBanDAO.getLastID();
            string MaPhieu = Common.XuLy.NextID(lastID, "PDB");
            phieuDatBan.MaPhieuDat = MaPhieu;
            phieuDatBan.NgayGioDat = DateTime.Now;
            phieuDatBan.NgayGioNhan = DateTime.Parse(NgayDen+" "+GioDen+":00", new CultureInfo("fr-FR", false));
            phieuDatBan.SoLuongNguoi = SLnguoi;
            phieuDatBan.MaViTri = maVitri;
            phieuDatBan.MaKH = session.UserID;
            int result = phieuDatBanDAO.insertPhieuDatBan(phieuDatBan);
            string strGenHTMLAlerSuccess = GenHTMLAlerSuccess(session,phieuDatBan);
            if (result == 1)
            {
                BuildEmail(phieuDatBan);
                return Json(new {error=false,genHTMLAlert=strGenHTMLAlerSuccess }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { error = true, genHTMLAlert = "" }, JsonRequestBehavior.AllowGet);
        }

        private void BuildEmail(PhieuDatBan phieuDatBan)
        {
            string content = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "XacNhanDat" + ".cshtml");
            var regInfo = new KhachHangDAO().getKhachhangByID(phieuDatBan.MaKH);
            var Vitri = new ViTriDAO().layVitriByMaVT(phieuDatBan.MaViTri);
            var loaiKV = new KhuVucDAO().LayLoaiKVByMaVitri(Vitri.MaViTri);
            
            content = content.Replace("{{Name}}", regInfo.TenKH);
            content = content.Replace("{{Ngaygiodat}}", phieuDatBan.NgayGioDat.ToString());
            content = content.Replace("{{NgaygioNhan}}", phieuDatBan.NgayGioNhan.ToString());
            content = content.Replace("{{SLNguoi}}", phieuDatBan.SoLuongNguoi.ToString());
            content = content.Replace("{{KhuVuc}}",loaiKV.TenLoaiKhuVuc);
            content = content.Replace("{{ViTri}}", Vitri.TenViTri);

            if(phieuDatBan.DatMonTruoc != 0)
            {
                content = content.Replace("{{Tiendatcoc}}", phieuDatBan.DatMonTruoc.ToString());
            }
            else
            {
                content = content.Replace("{{Tiendatcoc}}", "200.000 VND");
            }

            new MailHelper().SendMail(regInfo.Email, "Xác nhận đặt bàn", content);
        }

        public string GenHTMLAlerSuccess(SessionUserBO session,PhieuDatBan phieudatban)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<p>* Đặt chỗ tới nhà hàng <font color='black'><b>Món Việt</b></font> - <b>Số 140 Lê Trọng Tấn, P.Tân Bình, Q. Tân Phú</b> đã được tiếp nhận thành công! </p>");
            sb.AppendFormat("<p></p>");
            sb.AppendFormat("<p>* Nhân viên sẽ gọi điện tới số ĐT: <b>{0} để xác nhận trước {1} ngày {2}</b>. Vui lòng giữ liên lạc!</p>",session.PhoneNumber,phieudatban.NgayGioNhan.Value.ToShortTimeString(),phieudatban.NgayGioNhan.Value.ToShortDateString());
            sb.AppendFormat("<p>* Lưu ý: Quý Khách vui lòng chủ động gọi đến số: <b>19006005</b> để Nhân viên Xác nhận trong trường hợp Nhân viên cố gắng liên lạc không thành công!</p>");
            sb.AppendFormat("<p>*Quý Khách vui lòng kiểm tra email để có thể tới nhà hàng chúng tôi xác nhận đặt tiệc.</p>");
            sb.AppendFormat("<p> Đặt chỗ thành công chỉ khi có sự Xác nhận từ <span style:'font-size:15px'><b>Nhà hàng Món Việt!</b></span></p>");
            sb.AppendFormat("<p></p>");
            sb.AppendFormat("<p> Cảm ơn Quý Khách đã sử dụng Dịch vụ của chúng tôi!</p>");
            sb.AppendFormat("<p></p>");
            return sb.ToString();
        }
    }
}