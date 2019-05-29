namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuTrach")]
    public partial class PhuTrach
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime NgayLam { get; set; }

        public int? SLViTri { get; set; }

        public TimeSpan? TuGio { get; set; }

        public TimeSpan? DenGio { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaViTri { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string MaDKCa { get; set; }

        public virtual ThongTinDKCa ThongTinDKCa { get; set; }

        public virtual ViTri ViTri { get; set; }
    }
}
