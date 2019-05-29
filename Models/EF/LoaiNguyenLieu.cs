namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiNguyenLieu")]
    public partial class LoaiNguyenLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiNguyenLieu()
        {
            NguyenLieux = new HashSet<NguyenLieu>();
        }

        [Key]
        [StringLength(10)]
        public string MaLoaiNguyenLieu { get; set; }

        [StringLength(100)]
        public string TenLoaiNguyenLieu { get; set; }

        [StringLength(100)]
        public string DienGiai { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieu> NguyenLieux { get; set; }
    }
}
