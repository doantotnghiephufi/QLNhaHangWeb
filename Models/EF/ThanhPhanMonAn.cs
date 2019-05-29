namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhPhanMonAn")]
    public partial class ThanhPhanMonAn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaMonAn { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaNguyenLieu { get; set; }

        public double? SoLuongNL { get; set; }

        public virtual MonAn MonAn { get; set; }

        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
