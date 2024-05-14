using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Infrastructure.Models;

namespace Infrastructure.Models
{
    public partial class UniversidadContext : DbContext
    {
        public UniversidadContext()
        {
        }

        public UniversidadContext(DbContextOptions<UniversidadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Maestro> Maestros { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<Seccione> Secciones { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//               // optionsBuilder.UseSqlServer("Server=DESKTOP-01CRR3L\\SQLEXPRESS;Database=Universidad;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Carreras");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdEstudiante)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdSeccion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matriculas_Estudiantes");

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdSeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matriculas_Secciones");
            });

            modelBuilder.Entity<Seccione>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Aula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdMaestro)
                    .HasMaxLength(50)
                    .IsUnicode(false);
    
                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.Secciones)
                    .HasForeignKey(d => d.IdClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Secciones_Clases");

                entity.HasOne(d => d.IdMaestroNavigation)
                    .WithMany(p => p.Secciones)
                    .HasForeignKey(d => d.IdMaestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Secciones_Maestros");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
