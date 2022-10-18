namespace KarmaModels.KarmaModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [StringLength(10)]
        public string accountId { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string pass { get; set; }

        [StringLength(10)]
        public string customerId { get; set; }

        public virtual customer customer { get; set; }
    }
}
