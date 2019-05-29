namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietThucUong")]
    public partial class ChiTietThucUong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaThucUong { get; set; }

        public int? SoLuongDat { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual ThucUong ThucUong { get; set; }
    }
}
