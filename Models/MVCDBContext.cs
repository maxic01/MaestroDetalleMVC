using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MaestroDetalleMVC.Models
{
    public partial class MVCDBContext : DbContext
    {
        public MVCDBContext()
        {
        }

        public MVCDBContext(DbContextOptions<MVCDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-U2NBR94\\SQLEXPRESS;Initial Catalog=MVCDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.NroDetalle)
                    .HasName("PK__detalle___D582A832F471BCD5");

                entity.ToTable("detalle_facturas");

                entity.Property(e => e.NroDetalle).HasColumnName("nro_detalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.NroFactura).HasColumnName("nro_factura");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_unitario");

                entity.Property(e => e.Producto)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("producto");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.NroFacturaNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.NroFactura)
                    .HasConstraintName("FK_nro_factura");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.NroFactura)
                    .HasName("PK__facturas__B31FA9AF5696D321");

                entity.ToTable("facturas");

                entity.Property(e => e.NroFactura).HasColumnName("nro_factura");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numero_documento");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
