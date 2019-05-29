using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using System.Text;
using OnlineShop.Common;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class FoodController : Controller
    {
        // GET: Admin/Food
        public ActionResult CreateFood()
        {
            List<LoaiMonAn> lstFoodType = new LoaiMonAnDAO().getDSLoaiMonAn();
            ViewBag.ComboFoodType = genComboLoaiMonAn(lstFoodType);
            return View();
        }
        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase file)
        {
            string roothPath = "/Content/Images/" + file.FileName;
            file.SaveAs(Server.MapPath(roothPath));
            return Json(new { urlImg = roothPath, name = file.FileName });
            
        }
        [HttpPost]
        public JsonResult CreateFoodAjax(HttpPostedFileBase file,string tenmonan,int loaimonanID)
        {
            try
            {
                MonAnDAO objDAO = new MonAnDAO();
                MonAn objMonAn = new MonAn();
                objMonAn.MaMonAn = XuLy.NextID(objDAO.getLastID(), "MA");
                objMonAn.TenMonAn = tenmonan;
                int dataLength = (int)file.InputStream.Length;
                byte[] _byteArr = new byte[dataLength];
                file.InputStream.Read(_byteArr, 0, dataLength);
                objMonAn.HinhAnh = _byteArr;
                objMonAn.MaLoaiMonAn = loaimonanID.ToString();
                int result = objDAO.insertMonAn(objMonAn);
                if(result==2)
                {
                    return Json(new { iserror = false,isExist=true });
                }
                else
                {
                    if(result==1)
                    {
                        return Json(new { iserror = false,isExist=false });
                    }
                }
                return Json(new { iserror = true,messageError="Đã xảy ra lỗi khi thêm mới. Vui lòng kiểm tra lại!"});
            }
            catch(Exception ex)
            {
                return Json(new { iserror = true ,messageError = ex.Message});
            }
        }

        public string genComboLoaiMonAn(List<LoaiMonAn> lstFoodType)
        {
            StringBuilder sb = new StringBuilder();
            if(lstFoodType.Count >0 && lstFoodType != null)
            {
                foreach (LoaiMonAn item in lstFoodType)
                {
                    sb.Append(@"<option value='"+item.MaLoaiMonAn+"'>"+item.MaLoaiMonAn+"-"+item.TenLoaiMonAn+"</option>");
                }
            }
            return sb.ToString();
        }

        
    }
}