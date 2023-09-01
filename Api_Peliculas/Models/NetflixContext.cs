using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Peliculas.Models;

public partial class NetflixContext : DbContext
{
    public NetflixContext()
    {
    }

    public NetflixContext(DbContextOptions<NetflixContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<RelacionPeliculasTipo> RelacionPeliculasTipos { get; set; }

    public virtual DbSet<RelacionPersonasTipo> RelacionPersonasTipos { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.CodigoPelicula).HasName("PK__Pelicula__5D24DAE37AC86C4A");

            entity.Property(e => e.CodigoPelicula).HasColumnName("codigo_pelicula");
            entity.Property(e => e.FechaEstreno)
                .HasColumnType("date")
                .HasColumnName("fecha_estreno");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.NombrePelicula)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre_pelicula");
            entity.Property(e => e.TiempoDuracion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tiempo_duracion");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.CodigoPersona).HasName("PK__Personas__CD2887CA08ED336F");

            entity.Property(e => e.CodigoPersona).HasColumnName("codigo_persona");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<RelacionPeliculasTipo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Relacion__40F9A20765322622");

            entity.ToTable("Relacion_peliculas_tipos");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodigoPelicula).HasColumnName("codigo_pelicula");
            entity.Property(e => e.CodigoTipo).HasColumnName("codigo_tipo");

            entity.HasOne(d => d.CodigoPeliculaNavigation).WithMany(p => p.RelacionPeliculasTipos)
                .HasForeignKey(d => d.CodigoPelicula)
                .HasConstraintName("FK__Relacion___codig__3A81B327");

            entity.HasOne(d => d.CodigoTipoNavigation).WithMany(p => p.RelacionPeliculasTipos)
                .HasForeignKey(d => d.CodigoTipo)
                .HasConstraintName("FK__Relacion___codig__3B75D760");
        });

        modelBuilder.Entity<RelacionPersonasTipo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Relacion__40F9A207462306BF");

            entity.ToTable("Relacion_Personas_tipos");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodigoPersona).HasColumnName("codigo_persona");
            entity.Property(e => e.CodigoTipo).HasColumnName("codigo_tipo");

            entity.HasOne(d => d.CodigoPersonaNavigation).WithMany(p => p.RelacionPersonasTipos)
                .HasForeignKey(d => d.CodigoPersona)
                .HasConstraintName("FK__Relacion___codig__3F466844");

            entity.HasOne(d => d.CodigoTipoNavigation).WithMany(p => p.RelacionPersonasTipos)
                .HasForeignKey(d => d.CodigoTipo)
                .HasConstraintName("FK__Relacion___codig__403A8C7D");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Tipos__40F9A207F33878C3");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
