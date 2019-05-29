namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietComBo")]
    public partial class ChiTietComBo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaComBo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaMonAn { get; set; }

        public int? SLMon { get; set; }

        public virtual ComBo ComBo { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
