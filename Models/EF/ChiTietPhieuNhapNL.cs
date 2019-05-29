namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuNhapNL")]
    public partial class ChiTietPhieuNhapNL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaNguyenLieu { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaPN { get; set; }

        public double? SoLuongNhap { get; set; }

        public double? Gia { get; set; }

        public virtual PhieuNhapNL PhieuNhapNL { get; set; }
    }
}
