namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETSP")]
    public partial class CHITIETSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHITIETSP()
        {
            CHITIETDHs = new HashSet<CHITIETDH>();
        }

        public int MaSP { get; set; }

        public int MaSize { get; set; }

        public int MaMau { get; set; }

        [Key]
        public int MaChiTietSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDH> CHITIETDHs { get; set; }

        public virtual MAUSAC MAUSAC { get; set; }

        public virtual SIZE SIZE { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
