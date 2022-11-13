namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHMUCSP")]
    public partial class DANHMUCSP
    {
        [Key]
        public int MaDM { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDM { get; set; }
    }
}
