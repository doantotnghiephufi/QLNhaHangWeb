namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuVuc")]
    public partial class KhuVuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuVuc()
        {
            ViTris = new HashSet<ViTri>();
        }

        [Key]
        [StringLength(10)]
        public string MaKhuVuc { get; set; }

        [StringLength(100)]
        public string TenKhuVuc { get; set; }

        [StringLength(10)]
        public string MaLoaiKhuVuc { get; set; }

        public int? SLKhachMax { get; set; }

        public int? SLKhachMin { get; set; }

        public int? SLViTriMax { get; set; }

        public int? SLTrongHT { get; set; }

        public int? TrangThai { get; set; }

        [StringLength(100)]
        public string DienGiai { get; set; }

        public virtual LoaiKhuVuc LoaiKhuVuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViTri> ViTris { get; set; }
    }
}
