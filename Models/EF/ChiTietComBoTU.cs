namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietComBoTU")]
    public partial class ChiTietComBoTU
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaComBo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaThucUong { get; set; }

        public int? SLThucUong { get; set; }

        public virtual ComBo ComBo { get; set; }

        public virtual ThucUong ThucUong { get; set; }
    }
}
