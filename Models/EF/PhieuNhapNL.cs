namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapNL")]
    public partial class PhieuNhapNL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapNL()
        {
            ChiTietPhieuNhapNLs = new HashSet<ChiTietPhieuNhapNL>();
        }

        [Key]
        [StringLength(10)]
        public string MaPN { get; set; }

        [StringLength(10)]
        public string MaDDatNL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public double? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhapNL> ChiTietPhieuNhapNLs { get; set; }

        public virtual DonDatNL DonDatNL { get; set; }
    }
}
