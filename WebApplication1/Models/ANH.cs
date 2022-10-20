namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANH")]
    public partial class ANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANH()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }

        [Key]
        public int MaAnh { get; set; }

        [StringLength(50)]
        public string Anh1 { get; set; }

        [StringLength(50)]
        public string Anh2 { get; set; }

        [StringLength(50)]
        public string Anh3 { get; set; }

        [StringLength(50)]
        public string Anh4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
