namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinDKCa")]
    public partial class ThongTinDKCa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinDKCa()
        {
            PhuTraches = new HashSet<PhuTrach>();
        }

        [Key]
        [StringLength(10)]
        public string MaDKCa { get; set; }

        public DateTime? GioDK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLam { get; set; }

        public int? TrangThai { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(10)]
        public string MaCaLam { get; set; }

        public virtual CaLam CaLam { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhuTrach> PhuTraches { get; set; }
    }
}
