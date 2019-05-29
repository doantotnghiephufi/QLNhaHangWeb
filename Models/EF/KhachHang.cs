namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
            PhieuDatBans = new HashSet<PhieuDatBan>();
        }

        [Key]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        [StringLength(13)]
        public string CMND { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string DiaChiKH { get; set; }

        public double? TichLuy { get; set; }

        public DateTime? NgayTaoTT { get; set; }

        [StringLength(10)]
        public string MaKMKH { get; set; }

        [StringLength(32)]
        public string PASSWORD { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Activation { get; set; }
        public bool isValid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KhuyenMaiKH KhuyenMaiKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatBan> PhieuDatBans { get; set; }
    }
}
