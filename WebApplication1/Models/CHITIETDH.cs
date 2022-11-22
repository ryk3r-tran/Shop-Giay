namespace WebApplication1.Models
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
        public int MaDH { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSize { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMau { get; set; }

        public virtual MAUSAC MAUSAC { get; set; }

        public virtual MAUSAC MAUSAC1 { get; set; }

        public virtual SIZE SIZE { get; set; }

        public virtual SIZE SIZE1 { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual SANPHAM SANPHAM1 { get; set; }

        public virtual DONHANG DONHANG { get; set; }
    }
}
