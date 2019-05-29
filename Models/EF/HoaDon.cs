namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHDComBoes = new HashSet<ChiTietHDComBo>();
            ChiTietMonAns = new HashSet<ChiTietMonAn>();
            ChiTietThucUongs = new HashSet<ChiTietThucUong>();
        }

        [Key]
        [StringLength(10)]
        public string MaHD { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(10)]
        public string MaKMHD { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(10)]
        public string MaViTri { get; set; }

        [StringLength(10)]
        public string MaPhieuDat { get; set; }

        public DateTime? GioLapHD { get; set; }

        public DateTime? GioThanhToan { get; set; }

        public double? TongTien { get; set; }

        public double? GiamGia { get; set; }

        public double? ThanhTien { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHDComBo> ChiTietHDComBoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietMonAn> ChiTietMonAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThucUong> ChiTietThucUongs { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual KMGiamGiaHD KMGiamGiaHD { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuDatBan PhieuDatBan { get; set; }

        public virtual ViTri ViTri { get; set; }
    }
}
