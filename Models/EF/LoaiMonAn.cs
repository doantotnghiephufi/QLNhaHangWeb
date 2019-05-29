namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiMonAn")]
    public partial class LoaiMonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiMonAn()
        {
            MonAns = new HashSet<MonAn>();
        }

        [Key]
        [StringLength(10)]
        public string MaLoaiMonAn { get; set; }

        [StringLength(100)]
        public string TenLoaiMonAn { get; set; }

        [StringLength(100)]
        public string DienGiai { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonAn> MonAns { get; set; }
    }
}
