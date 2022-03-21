using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace QlySpa.Models.EF
{
    public partial class SpaDBContext : DbContext
    {
        public SpaDBContext()
            : base("name=SpaDBContext")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<ACCOUNT_ROLE> ACCOUNT_ROLE { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
       // public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VouCher> VouChers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ACCOUNT_ROLE)
                .WithOptional(e => e.ACCOUNT)
                .HasForeignKey(e => e.ID_ACCOUNT);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.dienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiDichVu>()
                .HasMany(e => e.SanPhams)
                .WithMany(e => e.LoaiDichVus)
                .Map(m => m.ToTable("SanPham_LoaiDichVu").MapLeftKey("idLoaiDV").MapRightKey("idSanPham"));

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.dienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.ACCOUNT_ROLE)
                .WithOptional(e => e.ROLE)
                .HasForeignKey(e => e.ID_ROLE);
        }
    }
}
