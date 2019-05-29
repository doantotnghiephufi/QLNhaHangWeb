using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class KhuVucDAO
    {
        NhaHangDbContext db;
        public KhuVucDAO()
        {
            db = new EF.NhaHangDbContext();
        }
        public List<LoaiKhuVuc> layDsLoaiKhuVuc()
        {
            return db.LoaiKhuVucs.ToList<LoaiKhuVuc>();
        }
        public List<KhuVuc> getListKhuVuc()
        {
            return db.KhuVucs.ToList<KhuVuc>();
        }
        public List<KhuVuc> layDSKhuVucTheoLoaiKV(string maLoaiKv,int SLNguoi)
        {
            return db.KhuVucs.Where(t => t.MaLoaiKhuVuc == maLoaiKv && SLNguoi >= t.SLKhachMin && SLNguoi <=t.SLKhachMax).ToList<KhuVuc>();
        }
        public LoaiKhuVuc LayLoaiKVByMaVitri(string mavt)
        {
            ViTri vt = new ViTriDAO().layVitriByMaVT(mavt);
            if (vt != null)
            {
                var Khuvuc = db.KhuVucs.Where(t => t.MaKhuVuc == vt.MaKhuVuc).FirstOrDefault();
                if(Khuvuc != null)
                {

                    var LoaiKV = db.LoaiKhuVucs.Where(t => t.MaLoaiKhuVuc == Khuvuc.MaLoaiKhuVuc);
                    return (LoaiKhuVuc)LoaiKV;
                }
            }
            return null;
        }
    }
}
