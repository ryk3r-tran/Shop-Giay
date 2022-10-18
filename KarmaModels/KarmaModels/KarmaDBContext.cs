using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;
namespace KarmaModels.KarmaModels
{
    public partial class KarmaDBContext : DbContext
    {
        public KarmaDBContext()
            : base("name=KarmaContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<customer> customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
