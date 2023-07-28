using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_El_Colombiano.Models;

public partial class BdproyectosContext : DbContext
{
    public BdproyectosContext()
    {
    }

    public BdproyectosContext(DbContextOptions<BdproyectosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonasInteresada> PersonasInteresadas { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonasInteresada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personas__3214EC27D083DE28");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NumeroTelefono).HasMaxLength(20);

            entity.HasOne(d => d.ProyectoDeInteresNavigation).WithMany(p => p.PersonasInteresada)
                .HasForeignKey(d => d.ProyectoDeInteres)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PersonasI__Proye__267ABA7A");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Proyecto__06370DAD71653AC9");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Constructora).HasMaxLength(100);
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
