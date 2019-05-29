namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDDNL")]
    public partial class ChiTietDDNL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaNguyenLieu { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaDDatNL { get; set; }

        public double? SoLuongDat { get; set; }

        public virtual DonDatNL DonDatNL { get; set; }

        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
