using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Proyecto.Models;

namespace Proyecto.Data
{
    public partial class HoteleriaContext : DbContext
    {
        public HoteleriaContext()
        {
        }

        public HoteleriaContext(DbContextOptions<HoteleriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlquilerCasa> AlquilerCasas { get; set; } = null!;
        public virtual DbSet<Casa> Casas { get; set; } = null!;
        public virtual DbSet<CobroAlquiler> CobroAlquilers { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<RegistrarVisitum> RegistrarVisita { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlquilerCasa>(entity =>
            {
                entity.ToTable("alquilerCasa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdCasa).HasColumnName("idCasa");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCasaNavigation)
                    .WithMany(p => p.AlquilerCasas)
                    .HasForeignKey(d => d.IdCasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alquilerLocal_casa");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.AlquilerCasas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__alquilerL__idPer__173876EA");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AlquilerCasas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alquilerCasa_usuario");
            });

            modelBuilder.Entity<Casa>(entity =>
            {
                entity.ToTable("casa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estadocasa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estadocasa");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Medidas)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("medidas");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NroCasa)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("nroCasa");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("precio");

                entity.Property(e => e.StatusFl)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status_fl");
            });

            modelBuilder.Entity<CobroAlquiler>(entity =>
            {
                entity.ToTable("cobroAlquiler");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.EstadoPago)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estadoPago");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idalquilar).HasColumnName("idalquilar");

                entity.Property(e => e.Multas)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("multas");

                entity.Property(e => e.ProximoPago)
                    .HasColumnType("date")
                    .HasColumnName("proximoPago");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdalquilarNavigation)
                    .WithMany(p => p.CobroAlquilers)
                    .HasForeignKey(d => d.Idalquilar)
                    .HasConstraintName("FK__cobroAlqu__idalq__1BFD2C07");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Carnet)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("carnet");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_empleados_rol");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Carnet)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("carnet");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.MiembrosFamilia).HasColumnName("miembrosFamilia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<RegistrarVisitum>(entity =>
            {
                entity.ToTable("registrarVisita");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CantidadPersonas).HasColumnName("cantidadPersonas");

                entity.Property(e => e.Carnet)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("carnet");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.NombreVisita)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreVisita");

                entity.Property(e => e.PlacaVehiculo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("placaVehiculo");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.RegistrarVisita)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__registrar__idPer__48CFD27E");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.IdPermisos).HasColumnName("idPermisos");

                entity.Property(e => e.Nombrecargo)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("nombrecargo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contra)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contra");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__usuario__idEmple__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
