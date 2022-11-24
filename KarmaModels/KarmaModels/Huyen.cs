namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Huyen")]
    public partial class Huyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Huyen()
        {
            Xas = new HashSet<Xa>();
        }

        [Key]
        public int MaHuyen { get; set; }

        [StringLength(20)]
        public string TenHuyen { get; set; }

        public int? MaTinh { get; set; }

        public virtual Tinh Tinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Xa> Xas { get; set; }
    }
}
