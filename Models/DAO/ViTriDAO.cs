using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;


namespace Models.DAO
{
    public class ViTriDAO
    {
        NhaHangDbContext db=null;
        public ViTriDAO()
        {
            db = new EF.NhaHangDbContext();
        }
        public List<ViTri> LayDSViTriConTrong(string makv,DateTime ngayGioDat,DateTime ngayGioDen)
        {
            DateTime dt = ngayGioDen.AddHours(-2);
            var listVitri = from vt in db.ViTris
                            join kv in db.KhuVucs on vt.MaKhuVuc equals kv.MaKhuVuc
                            where vt.MaKhuVuc == makv &&
                            !(from pd in db.PhieuDatBans
                             where pd.NgayGioNhan <= ngayGioDen &&
                             pd.NgayGioNhan >= dt
                             select pd.MaViTri).Contains(vt.MaViTri)
                            select vt;
            return listVitri.ToList<ViTri>();

        }
        public ViTri layVitriByMaVT(string mavt)
        {
            return db.ViTris.Where(t => t.MaViTri == mavt).FirstOrDefault();
        }
        public DateTime DateADD(DateTime? dt)
        {
            return dt.Value.AddHours(2);
        }
        public List<string> layPhieuDatBan(DateTime ngayGioDat, DateTime ngayGioDen)
        {
            ngayGioDat = ngayGioDat.AddHours(2);
            ngayGioDen = ngayGioDen.AddHours(2);
            var listVitri = from pd in db.PhieuDatBans
                            where pd.NgayGioDat <= ngayGioDat &&
                            pd.NgayGioNhan >= ngayGioDen
                            select pd.MaViTri;
            return listVitri.ToList<string>();
        }
    }
}
