namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Xa")]
    public partial class Xa
    {
        [Key]
        public int MaXa { get; set; }

        [Required]
        [StringLength(50)]
        public string TenXa { get; set; }

        public int? MaHuyen { get; set; }

        public virtual Huyen Huyen { get; set; }
    }
}
