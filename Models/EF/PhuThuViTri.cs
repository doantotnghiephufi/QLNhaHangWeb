namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuThuViTri")]
    public partial class PhuThuViTri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhuThuViTri()
        {
            ViTris = new HashSet<ViTri>();
        }

        [Key]
        [StringLength(10)]
        public string MaPhuThu { get; set; }

        [StringLength(100)]
        public string TenPhuThu { get; set; }

        public double? PhuThu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViTri> ViTris { get; set; }
    }
}
