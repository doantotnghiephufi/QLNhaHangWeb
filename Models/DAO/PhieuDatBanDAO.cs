using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class PhieuDatBanDAO
    {
        NhaHangDbContext db = null;
        public PhieuDatBanDAO()
        {
            db = new EF.NhaHangDbContext();
        }
        
        public string getLastID()
        {
            PhieuDatBan PhieuDatBan = new PhieuDatBan ();
            PhieuDatBan = db.PhieuDatBans.OrderByDescending(t => t.MaPhieuDat).Skip(0).Take(1).FirstOrDefault();
            if (PhieuDatBan != null)
            {
                return PhieuDatBan.MaPhieuDat;
            }
            return "";
        }
        public List<PhieuDatBan> getListPhieuDatBan()
        {
            return db.PhieuDatBans.Select(t => t).ToList<PhieuDatBan>();
        }

        bool ktKhoachinh(string MaPhieuDat)
        {
            PhieuDatBan ma = db.PhieuDatBans.Where(t => t.MaPhieuDat == MaPhieuDat).FirstOrDefault();
            if (ma != null)
            {
                return true;
            }
            return false;
        }
        public int insertPhieuDatBan(PhieuDatBan PhieuDatBan)
        {
            if (ktKhoachinh(PhieuDatBan.MaPhieuDat))
            {
                return 2;
            }
            try
            {
                db.PhieuDatBans.Add(PhieuDatBan);
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
