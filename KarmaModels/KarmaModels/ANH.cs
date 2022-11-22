namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANH")]
    public partial class ANH
    {
        [Key]
        public int MaAnh { get; set; }

        [StringLength(50)]
        public string TenAnh { get; set; }

        [StringLength(50)]
        public string AnhChinh { get; set; }

        [StringLength(50)]
        public string AnhPhu1 { get; set; }

        [StringLength(50)]
        public string AnhPhu2 { get; set; }

        [StringLength(50)]
        public string AnhPhu3 { get; set; }
    }
}
