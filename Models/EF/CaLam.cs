namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaLam")]
    public partial class CaLam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaLam()
        {
            ThongTinDKCas = new HashSet<ThongTinDKCa>();
        }

        [Key]
        [StringLength(10)]
        public string MaCaLam { get; set; }

        [StringLength(100)]
        public string TenCaLam { get; set; }

        public TimeSpan? GioBD { get; set; }

        public TimeSpan? GioKT { get; set; }

        public int? SoNVToiDa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinDKCa> ThongTinDKCas { get; set; }
    }
}
