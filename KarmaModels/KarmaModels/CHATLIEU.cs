namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHATLIEU")]
    public partial class CHATLIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHATLIEU()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }

        [Key]
        public int MaCL { get; set; }

        [Column("ChatLieu")]
        [StringLength(20)]
        public string ChatLieu1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
