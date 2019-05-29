namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuyenMaiKH")]
    public partial class KhuyenMaiKH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuyenMaiKH()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaKMKH { get; set; }

        [StringLength(100)]
        public string TenKM { get; set; }

        public double? GiamGia { get; set; }

        public double? DinhMucSuDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
