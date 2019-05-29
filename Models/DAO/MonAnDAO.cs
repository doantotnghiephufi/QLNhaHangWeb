using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class MonAnDAO
    {
        NhaHangDbContext db=null;
        public MonAnDAO()
        {
            db = new EF.NhaHangDbContext();
        }
        public MonAn getMonAnByID(string MaMonAn)
        {
            return db.MonAns.Where(t => t.MaMonAn == MaMonAn).FirstOrDefault();
        }
        public string getLastID()
        {
            MonAn monan = new MonAn();
            monan= db.MonAns.OrderByDescending(t => t.MaMonAn).Skip(0).Take(1).FirstOrDefault();
            if(monan != null)
            {
                return monan.MaMonAn;
            }
            return "";
        }
        public List<MonAn> getListMonAn()
        {
            return db.MonAns.Select(t => t).ToList<MonAn>();
        }
        
        bool ktKhoachinh(string mamon)
        {
            MonAn ma = db.MonAns.Where(t => t.MaMonAn == mamon).FirstOrDefault();
            if (ma != null)
            {
                return true;
            }
            return false;
        }
        public int insertMonAn(MonAn monan)
        {
            if (ktKhoachinh(monan.MaMonAn))
            {
                return 2;
            }
            try
            {
                db.MonAns.Add(monan);
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
