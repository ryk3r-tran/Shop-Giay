using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=MyDBContext")
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
            modelBuilder.Entity<CHATLIEU>()
                .Property(e => e.ChatLieu1)
                .IsFixedLength();

            modelBuilder.Entity<CHATLIEU>()
                .HasMany(e => e.CHITIETSPs)
                .WithRequired(e => e.CHATLIEU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CHITIETDH>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DANHMUCSP>()
                .HasMany(e => e.CHITIETSPs)
                .WithRequired(e => e.DANHMUCSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CHITIETDHs)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.BINHLUANSPs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DANHGIAs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DONHANGs)
                .WithOptional(e => e.KHACHHANG)
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DONHANGs1)
                .WithOptional(e => e.KHACHHANG1)
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.TAIKHOANs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MAUSAC>()
                .HasMany(e => e.CHITIETDHs)
                .WithRequired(e => e.MAUSAC)
                .HasForeignKey(e => e.MaMau)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MAUSAC>()
                .HasMany(e => e.CHITIETDHs1)
                .WithRequired(e => e.MAUSAC1)
                .HasForeignKey(e => e.MaMau)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MAUSAC>()
                .HasMany(e => e.CHITIETSPs)
                .WithRequired(e => e.MAUSAC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NSX>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NSX>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NSX>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.NSX)
                .HasForeignKey(e => e.MaNSX);

            modelBuilder.Entity<NSX>()
                .HasMany(e => e.SANPHAMs1)
                .WithOptional(e => e.NSX1)
                .HasForeignKey(e => e.MaNSX);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.BINHLUANSPs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETDHs)
                .WithRequired(e => e.SANPHAM)
                .HasForeignKey(e => e.MaSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETDHs1)
                .WithRequired(e => e.SANPHAM1)
                .HasForeignKey(e => e.MaSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETSPs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.DANHGIAs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SIZE>()
                .HasMany(e => e.CHITIETDHs)
                .WithRequired(e => e.SIZE)
                .HasForeignKey(e => e.MaSize)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SIZE>()
                .HasMany(e => e.CHITIETDHs1)
                .WithRequired(e => e.SIZE1)
                .HasForeignKey(e => e.MaSize)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SIZE>()
                .HasMany(e => e.CHITIETSPs)
                .WithRequired(e => e.SIZE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.pass)
                .IsUnicode(false);
        }
    }
}
