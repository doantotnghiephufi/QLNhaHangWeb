using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class LoaiMonAnDAO
    {
        NhaHangDbContext db;
        public LoaiMonAnDAO()
        {
            db = new EF.NhaHangDbContext();
        }
        public List<LoaiMonAn> getDSLoaiMonAn()
        {
            try
            {
                List<LoaiMonAn> lstLoaiMonAn = db.LoaiMonAns.ToList<LoaiMonAn>();
                return lstLoaiMonAn;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
