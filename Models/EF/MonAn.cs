namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonAn")]
    public partial class MonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAn()
        {
            ChiTietComBoes = new HashSet<ChiTietComBo>();
            ChiTietDatMonAns = new HashSet<ChiTietDatMonAn>();
            ChiTietMonAns = new HashSet<ChiTietMonAn>();
            ThanhPhanMonAns = new HashSet<ThanhPhanMonAn>();
        }

        [Key]
        [StringLength(10)]
        public string MaMonAn { get; set; }

        [StringLength(100), Display(Name = "Tên món ăn")]
        public string TenMonAn { get; set; }

        [StringLength(20), Display(Name = "Đơn vị tính")]
        public string DonViTinh { get; set; }
        [Display(Name = "Số lượng tồn")]
        public double? SoLuongTon
        {
            get; set;
        }
        [Display(Name = "Trạng thái")]
        public int? TrangThai { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        [StringLength(10), Display(Name = "Loại món ăn")]
        public string MaLoaiMonAn { get; set; }

        public double? GiaMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietComBo> ChiTietComBoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatMonAn> ChiTietDatMonAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietMonAn> ChiTietMonAns { get; set; }

        public virtual LoaiMonAn LoaiMonAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhPhanMonAn> ThanhPhanMonAns { get; set; }
    }
}
