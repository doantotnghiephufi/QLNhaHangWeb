namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatMonAn")]
    public partial class ChiTietDatMonAn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaPhieuDat { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaMonAn { get; set; }

        public int? SoLuongDat { get; set; }

        public virtual MonAn MonAn { get; set; }

        public virtual PhieuDatBan PhieuDatBan { get; set; }
    }
}
