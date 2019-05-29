using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;

namespace OnlineShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryFood(int pageSize=6,int pageIndex=0)
        {
            List<MonAn> listMonAn = new MonAnDAO().getListMonAn();
            listMonAn = listMonAn.Skip(pageSize * pageIndex).Take(pageSize).ToList();
            
            return PartialView("CategoryFood",listMonAn);
        }
        public ActionResult RetrieveImage(string id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public byte[] GetImageFromDataBase(string Id)
        {
            MonAn objMonAn = new MonAnDAO().getMonAnByID(Id);
            byte[] cover = objMonAn.HinhAnh;
            return cover;
        }
    }
}