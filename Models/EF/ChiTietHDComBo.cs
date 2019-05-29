namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHDComBo")]
    public partial class ChiTietHDComBo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaComBo { get; set; }

        public int? SoLuongDat { get; set; }

        public virtual ComBo ComBo { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
