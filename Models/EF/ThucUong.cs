namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucUong")]
    public partial class ThucUong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucUong()
        {
            ChiTietComBoTUs = new HashSet<ChiTietComBoTU>();
            ChiTietDatThucUongs = new HashSet<ChiTietDatThucUong>();
            ChiTietThucUongs = new HashSet<ChiTietThucUong>();
            ThanhPhanThucUongs = new HashSet<ThanhPhanThucUong>();
        }

        [Key]
        [StringLength(10)]
        public string MaThucUong { get; set; }

        [StringLength(100)]
        public string TenThucUong { get; set; }

        [StringLength(20)]
        public string DonViTinh { get; set; }

        public double? SoLuongTon { get; set; }

        public int? TrangThai { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        [StringLength(10)]
        public string MaLoaiThucUong { get; set; }

        public double? GiaThucUong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietComBoTU> ChiTietComBoTUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatThucUong> ChiTietDatThucUongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThucUong> ChiTietThucUongs { get; set; }

        public virtual LoaiThucUong LoaiThucUong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhPhanThucUong> ThanhPhanThucUongs { get; set; }
    }
}
