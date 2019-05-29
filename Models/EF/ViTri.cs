namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViTri")]
    public partial class ViTri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ViTri()
        {
            HoaDons = new HashSet<HoaDon>();
            PhieuDatBans = new HashSet<PhieuDatBan>();
            PhuTraches = new HashSet<PhuTrach>();
        }

        [Key]
        [StringLength(10)]
        public string MaViTri { get; set; }

        [StringLength(100)]
        public string TenViTri { get; set; }

        [StringLength(100)]
        public string DienGiai { get; set; }

        public int? TrangThai { get; set; }

        public int? SLNhanVienMax { get; set; }

        [StringLength(10)]
        public string MaPhuThu { get; set; }

        [StringLength(10)]
        public string MaKhuVuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KhuVuc KhuVuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatBan> PhieuDatBans { get; set; }

        public virtual PhuThuViTri PhuThuViTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhuTrach> PhuTraches { get; set; }
    }
}
