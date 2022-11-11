using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KarmaModels.KarmaModels
{
    public partial class KarmaDBContext : DbContext
    {
        public KarmaDBContext()
            : base("name=KarmaDBContext")
        {
        }

        public virtual DbSet<ANH> ANHs { get; set; }
        public virtual DbSet<BINHLUANSP> BINHLUANSPs { get; set; }
        public virtual DbSet<CHATLIEU> CHATLIEUx { get; set; }
        public virtual DbSet<CHITIETDH> CHITIETDHs { get; set; }
        public virtual DbSet<CHITIETSP> CHITIETSPs { get; set; }
        public virtual DbSet<DANHGIA> DANHGIAs { get; set; }
        public virtual DbSet<DANHMUCSP> DANHMUCSPs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<MAUSAC> MAUSACs { get; set; }
        public virtual DbSet<NSX> NSXes { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<SIZE> SIZEs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDH>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NSX>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NSX>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.pass)
                .IsUnicode(false);
        }
    }
}
