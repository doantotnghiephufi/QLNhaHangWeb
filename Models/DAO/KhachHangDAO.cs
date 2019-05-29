using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class KhachHangDAO
    {
        NhaHangDbContext db = null;
        public KhachHangDAO()
        {
            db = new EF.NhaHangDbContext();
        }
        public KhachHang getKhachhangByID(string id)
        {
            var kh = db.KhachHangs.Where(t => t.MaKH == id).FirstOrDefault();
            return kh;
        }
        public KhachHang getKhachHangByActication(string maKh,string Activation)
        {
            var kh = db.KhachHangs.Where(t => t.Activation == Activation).FirstOrDefault();
            return kh;
        }
        public string getLastID()
        {
            KhachHang kh = new KhachHang();
            kh = db.KhachHangs.OrderByDescending(t => t.MaKH).Skip(0).Take(1).FirstOrDefault();
            if (kh != null)
            {
                return kh.MaKH;
            }
            return "";
        }
        public List<KhachHang> getListKhachHang()
        {
            return db.KhachHangs.Select(t => t).ToList<KhachHang>();
        }
        public int updateIsValid(KhachHang objKh)
        {
            try
            {
                objKh.isValid = true;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        bool ktKhoachinh(string MaKH)
        {
            KhachHang kh = db.KhachHangs.Where(t => t.MaKH == MaKH).FirstOrDefault();
            if (kh != null)
            {
                return true;
            }
            return false;
        }
        public bool isExistSDT(string sdt)
        {
            KhachHang kh = db.KhachHangs.Where(t => t.SDT == sdt).FirstOrDefault();
            if (kh != null)
            {
                return true;
            }
            return false;
        }
        public bool isExistEmail(string Email)
        {
            KhachHang kh = db.KhachHangs.Where(t => t.Email == Email).FirstOrDefault();
            if (kh != null)
            {
                return true;
            }
            return false;
        }
        public int insertKhachHang(KhachHang KhachHang)
        {
            if (ktKhoachinh(KhachHang.MaKH))
            {
                return 2;
            }
            try
            {
                db.KhachHangs.Add(KhachHang);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
