namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComBo")]
    public partial class ComBo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComBo()
        {
            ChiTietComBoes = new HashSet<ChiTietComBo>();
            ChiTietComBoTUs = new HashSet<ChiTietComBoTU>();
            ChiTietDatComBoes = new HashSet<ChiTietDatComBo>();
            ChiTietHDComBoes = new HashSet<ChiTietHDComBo>();
        }

        [Key]
        [StringLength(10)]
        public string MaComBo { get; set; }

        [StringLength(100)]
        public string TenComBo { get; set; }

        [StringLength(100)]
        public string DienGiai { get; set; }

        public double? PhanTramGiamGia { get; set; }

        public double? TongTienGiam { get; set; }

        public double? TongTienTraCB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayApdung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        public int? TrangThai { get; set; }

        public double? TienGiam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietComBo> ChiTietComBoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietComBoTU> ChiTietComBoTUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatComBo> ChiTietDatComBoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHDComBo> ChiTietHDComBoes { get; set; }
    }
}
