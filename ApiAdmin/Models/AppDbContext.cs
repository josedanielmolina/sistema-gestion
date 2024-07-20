using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiAdmin.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BacklogsEvent> BacklogsEvents { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BacklogsEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompleteAt).HasColumnType("datetime");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.EventType).HasColumnType("int(11) unsigned");
            entity.Property(e => e.Json).IsRequired();
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cargo)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CodigoRh)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CodigoRH");
            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
