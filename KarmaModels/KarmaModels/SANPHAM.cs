namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            BINHLUANSPs = new HashSet<BINHLUANSP>();
            CHITIETSPs = new HashSet<CHITIETSP>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SoLuongTong { get; set; }

        public decimal? DonGia { get; set; }

        public string MoTa { get; set; }

        public int MaNSX { get; set; }

        public int MaAnh { get; set; }

        public int MaDM { get; set; }

        public int? MaCL { get; set; }

        public virtual ANH ANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUANSP> BINHLUANSPs { get; set; }

        public virtual CHATLIEU CHATLIEU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETSP> CHITIETSPs { get; set; }

        public virtual DANHMUCSP DANHMUCSP { get; set; }

        public virtual NSX NSX { get; set; }
    }
}
