namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KMGiamGiaHD")]
    public partial class KMGiamGiaHD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KMGiamGiaHD()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaKMHD { get; set; }

        [StringLength(100)]
        public string TenKM { get; set; }

        [StringLength(100)]
        public string DienGiai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianBD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianKT { get; set; }

        public double? PhanTramGiam { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
