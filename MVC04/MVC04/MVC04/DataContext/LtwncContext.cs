using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MVC04.Models;

namespace MVC04.DataContext
{
    public partial class LtwncContext : DbContext
    {
        public LtwncContext()
        {
        }

        public LtwncContext(DbContextOptions<LtwncContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Season> Seasons { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<Vegetable> Vegetables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GOAKFLS\\SQLEXPRESS;Database=Ltwnc;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tblProdu__B40CC6EDC5DD0DB8");

                entity.ToTable("tblProducts");

                entity.HasIndex(e => e.ProductName, "UC_ProductName")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Vegetable>(entity =>
            {
                entity.HasIndex(e => e.SeasonId, "IX_Vegetables_SeasonId");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Vegetables)
                    .HasForeignKey(d => d.SeasonId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
