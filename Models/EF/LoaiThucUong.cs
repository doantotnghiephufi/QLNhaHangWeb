namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiThucUong")]
    public partial class LoaiThucUong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiThucUong()
        {
            ThucUongs = new HashSet<ThucUong>();
        }

        [Key]
        [StringLength(10)]
        public string MaLoaiThucUong { get; set; }

        [StringLength(100)]
        public string TenLoaiThucUong { get; set; }

        [StringLength(100)]
        public string DienGiai { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThucUong> ThucUongs { get; set; }
    }
}
