namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        public int id { get; set; }

        public int MaKH { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string pass { get; set; }

        [StringLength(50)]
        public string Quyen { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
