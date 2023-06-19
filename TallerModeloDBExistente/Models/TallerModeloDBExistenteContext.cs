using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TallerModeloDBExistente.Models
{
    public partial class TallerModeloDBExistenteContext : DbContext
    {
        public TallerModeloDBExistenteContext()
        {
        }

        public TallerModeloDBExistenteContext(DbContextOptions<TallerModeloDBExistenteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Domicilio> Domicilios { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Alumno__460B4740232DF70C");

                entity.ToTable("Alumno");

                entity.Property(e => e.ApMaterno).HasMaxLength(30);

                entity.Property(e => e.ApPaterno).HasMaxLength(30);

                entity.Property(e => e.Nombre).HasMaxLength(30);
            });

            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.HasKey(e => e.IdDomicilio)
                    .HasName("PK__Domicili__1648AD8ACCF762AC");

                entity.ToTable("Domicilio");

                entity.Property(e => e.Calle).HasMaxLength(30);

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Domicilios)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("FK_IdAlumno");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PK__Matricul__AD06C20F06A45838");

                entity.ToTable("Matricula");

                entity.Property(e => e.DescripcionMaterias)
                    .HasMaxLength(100)
                    .HasColumnName("Descripcion_materias");

                entity.Property(e => e.NumeroMaterias).HasColumnName("Numero_materias");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("FK_IdAlumnos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
