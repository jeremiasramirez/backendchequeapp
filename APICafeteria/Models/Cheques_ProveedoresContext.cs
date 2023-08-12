using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APICafeteria.Models
{
    public partial class Cheques_ProveedoresContext : DbContext
    {
        public Cheques_ProveedoresContext()
        {
        }

        public Cheques_ProveedoresContext(DbContextOptions<Cheques_ProveedoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cheque> Cheques { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Pago1> Pagos1 { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<SolicitudRegistroCheque> SolicitudRegistroCheques { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Cheques_Proveedores;user=JEREMIAS-APEC;password='';Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cheque>(entity =>
            {
                entity.ToTable("Cheque");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NumCuentaCheque)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("Pago");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CuentaContable)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cuentaContable");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fecha");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.NombreProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreProveedor");
            });

            modelBuilder.Entity<Pago1>(entity =>
            {
                entity.ToTable("Pagos");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.ProveedorId)
                    .HasName("PK__Proveedo__0790A3EB07768F11");

                entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_ID");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaContable).HasColumnName("Cuenta_Contable");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SolicitudRegistroCheque>(entity =>
            {
                entity.ToTable("Solicitud_Registro_Cheque");

                entity.Property(e => e.CContableProveedor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("C_Contable_Proveedor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Fecha_Registro");

                entity.Property(e => e.NumeroSolicitud).HasColumnName("Numero_Solicitud");

                entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_ID");

                entity.Property(e => e.ProveedorNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Proveedor_Nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
