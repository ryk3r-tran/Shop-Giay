namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MAUSAC")]
    public partial class MAUSAC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MAUSAC()
        {
            CHITIETSPs = new HashSet<CHITIETSP>();
        }

        [Key]
        public int MaMau { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [StringLength(10)]
        public string MaHeXan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETSP> CHITIETSPs { get; set; }
    }
}
