using Antojitos.Web.Host.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Antojitos.Web.Host.Data
{
    public partial class AntojitosContext : DbContext
    {
        public AntojitosContext()
        {
        }

        public AntojitosContext(DbContextOptions<AntojitosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestCliente> TestClientes { get; set; }
        public virtual DbSet<TestFactura> TestFacturas { get; set; }
        public virtual DbSet<TestFacturaDetalle> TestFacturaDetalles { get; set; }
        public virtual DbSet<TestProducto> TestProductos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TestCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__TEST_CLI__D59466426917C2C2");

                entity.ToTable("TEST_CLIENTE");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Identifiacion).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<TestFactura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__TEST_FAC__50E7BAF17B77EACA");

                entity.ToTable("TEST_FACTURA");

                entity.Property(e => e.IdFactura)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaVenta).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ValorTotal).HasColumnType("numeric(18, 3)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TestFacturas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEST_FACT__Valor__286302EC");
            });

            modelBuilder.Entity<TestFacturaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdFacturaDetalle)
                    .HasName("PK__TEST_FAC__3D8E1AB89893AC03");

                entity.ToTable("TEST_FACTURA_DETALLE");

                entity.Property(e => e.IdFacturaDetalle)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdFactura).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdProducto).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ValorTotal).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ValorUnidad).HasColumnType("numeric(18, 3)");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.TestFacturaDetalles)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEST_FACT__IdFac__2B3F6F97");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.TestFacturaDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEST_FACT__IdPro__2C3393D0");
            });

            modelBuilder.Entity<TestProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__TEST_PRO__09889210E2A682D9");

                entity.ToTable("TEST_PRODUCTO");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ValorUnidad).HasColumnType("numeric(18, 3)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public static IConfiguration Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("Default");

        }
    }
}
