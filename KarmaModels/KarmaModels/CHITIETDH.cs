namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDH")]
    public partial class CHITIETDH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDH { get; set; }

        public int? SoLuong { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChiTietSP { get; set; }

        public virtual CHITIETSP CHITIETSP { get; set; }

        public virtual DONHANG DONHANG { get; set; }
    }
}
