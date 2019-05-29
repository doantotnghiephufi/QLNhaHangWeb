namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuDatBan")]
    public partial class PhieuDatBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuDatBan()
        {
            ChiTietDatComBoes = new HashSet<ChiTietDatComBo>();
            ChiTietDatMonAns = new HashSet<ChiTietDatMonAn>();
            ChiTietDatThucUongs = new HashSet<ChiTietDatThucUong>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaPhieuDat { get; set; }

        public DateTime? NgayGioDat { get; set; }

        public DateTime? NgayGioNhan { get; set; }

        public int? SoLuongNguoi { get; set; }

        public double? DatCoc { get; set; }

        public int? TinhTrang { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(10)]
        public string MaViTri { get; set; }
        [DefaultValue(0)]
        public int DatMonTruoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatComBo> ChiTietDatComBoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatMonAn> ChiTietDatMonAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatThucUong> ChiTietDatThucUongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual ViTri ViTri { get; set; }
    }
}
