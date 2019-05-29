namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiKhuVuc")]
    public partial class LoaiKhuVuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiKhuVuc()
        {
            KhuVucs = new HashSet<KhuVuc>();
        }

        [Key]
        [StringLength(10)]
        public string MaLoaiKhuVuc { get; set; }

        [StringLength(100)]
        public string TenLoaiKhuVuc { get; set; }

        public double? PhuThu { get; set; }

        [StringLength(5)]
        public string KiHieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhuVuc> KhuVucs { get; set; }
    }
}
