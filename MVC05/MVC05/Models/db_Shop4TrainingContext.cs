using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC05.Models
{
    public partial class db_Shop4TrainingContext : DbContext
    {
        public db_Shop4TrainingContext()
        {
        }

        public db_Shop4TrainingContext(DbContextOptions<db_Shop4TrainingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblChitiethoadon> TblChitiethoadons { get; set; } = null!;
        public virtual DbSet<TblCongDan> TblCongDans { get; set; } = null!;
        public virtual DbSet<TblHanghoa> TblHanghoas { get; set; } = null!;
        public virtual DbSet<TblHoadon> TblHoadons { get; set; } = null!;
        public virtual DbSet<TblKhachhang> TblKhachhangs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GOAKFLS\\SQLEXPRESS;Database=db_Shop4Training;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblChitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.FkIHoadonId, e.FkIHanghoaId });

                entity.ToTable("tblChitiethoadon");

                entity.Property(e => e.FkIHoadonId).HasColumnName("FK_iHoadonID");

                entity.Property(e => e.FkIHanghoaId).HasColumnName("FK_iHanghoaID");

                entity.Property(e => e.FGiaban).HasColumnName("fGiaban");

                entity.Property(e => e.ISoluong).HasColumnName("iSoluong");
            });

            modelBuilder.Entity<TblCongDan>(entity =>
            {
                entity.HasKey(e => e.PkICongDanId)
                    .HasName("PK__tblCongD__3982FC233BC1659D");

                entity.ToTable("tblCongDan");

                entity.Property(e => e.PkICongDanId)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_iCongDanID");

                entity.Property(e => e.SCmnd)
                    .HasMaxLength(500)
                    .HasColumnName("sCMND");

                entity.Property(e => e.SHoKhau)
                    .HasMaxLength(500)
                    .HasColumnName("sHoKhau");

                entity.Property(e => e.SHoTen)
                    .HasMaxLength(300)
                    .HasColumnName("sHoTen");

                entity.Property(e => e.TNgaySinh)
                    .HasColumnType("datetime")
                    .HasColumnName("tNgaySinh");
            });

            modelBuilder.Entity<TblHanghoa>(entity =>
            {
                entity.HasKey(e => e.PkIHanghoaId)
                    .HasName("PK_MatHang");

                entity.ToTable("tblHanghoa");

                entity.Property(e => e.PkIHanghoaId).HasColumnName("PK_iHanghoaID");

                entity.Property(e => e.FGianiemyet).HasColumnName("fGianiemyet");

                entity.Property(e => e.SAnhminhhoa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("sAnhminhhoa");

                entity.Property(e => e.SDacdiem)
                    .HasColumnType("ntext")
                    .HasColumnName("sDacdiem");

                entity.Property(e => e.STenhang)
                    .HasMaxLength(300)
                    .HasColumnName("sTenhang");

                entity.Property(e => e.SXuatxu)
                    .HasMaxLength(300)
                    .HasColumnName("sXuatxu");
            });

            modelBuilder.Entity<TblHoadon>(entity =>
            {
                entity.HasKey(e => e.PkIHoadonId)
                    .HasName("PK_HoaDon");

                entity.ToTable("tblHoadon");

                entity.Property(e => e.PkIHoadonId).HasColumnName("PK_iHoadonID");

                entity.Property(e => e.BDathanhtoan).HasColumnName("bDathanhtoan");

                entity.Property(e => e.FTileGiamgia).HasColumnName("fTileGiamgia");

                entity.Property(e => e.FkIKhachhangId).HasColumnName("FK_iKhachhangID");

                entity.Property(e => e.SDiachigiaohang)
                    .HasMaxLength(500)
                    .HasColumnName("sDiachigiaohang");

                entity.Property(e => e.SDienthoaiNguoinhan)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("sDienthoaiNguoinhan");

                entity.Property(e => e.SNguoilapHoadon)
                    .HasMaxLength(50)
                    .HasColumnName("sNguoilapHoadon");

                entity.Property(e => e.STennguoinhan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sTennguoinhan")
                    .IsFixedLength();

                entity.Property(e => e.TNgayGiaoHang)
                    .HasColumnType("datetime")
                    .HasColumnName("tNgayGiaoHang");

                entity.Property(e => e.TNgaylap)
                    .HasColumnType("datetime")
                    .HasColumnName("tNgaylap");
            });

            modelBuilder.Entity<TblKhachhang>(entity =>
            {
                entity.HasKey(e => e.PkIKhachhangId);

                entity.ToTable("tblKhachhang");

                entity.Property(e => e.PkIKhachhangId).HasColumnName("PK_iKhachhangID");

                entity.Property(e => e.BGioitinh).HasColumnName("bGioitinh");

                entity.Property(e => e.SDiachi)
                    .HasMaxLength(200)
                    .HasColumnName("sDiachi");

                entity.Property(e => e.SDienthoai)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("sDienthoai");

                entity.Property(e => e.SHoten)
                    .HasMaxLength(50)
                    .HasColumnName("sHoten");

                entity.Property(e => e.STenCoquan)
                    .HasMaxLength(100)
                    .HasColumnName("sTenCoquan");

                entity.Property(e => e.TNgaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("tNgaysinh");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
