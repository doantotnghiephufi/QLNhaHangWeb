namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguyenLieu")]
    public partial class NguyenLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguyenLieu()
        {
            ChiTietDDNLs = new HashSet<ChiTietDDNL>();
            ThanhPhanMonAns = new HashSet<ThanhPhanMonAn>();
            ThanhPhanThucUongs = new HashSet<ThanhPhanThucUong>();
        }

        [Key]
        [StringLength(10)]
        public string MaNguyenLieu { get; set; }

        [StringLength(100)]
        public string TenNguyenLieu { get; set; }

        [StringLength(20)]
        public string DonViTinhNL { get; set; }

        public double? TonKho { get; set; }

        public double? TonToiThieu { get; set; }

        [StringLength(10)]
        public string MaLoaiNguyenLieu { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDDNL> ChiTietDDNLs { get; set; }

        public virtual LoaiNguyenLieu LoaiNguyenLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhPhanMonAn> ThanhPhanMonAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhPhanThucUong> ThanhPhanThucUongs { get; set; }
    }
}
