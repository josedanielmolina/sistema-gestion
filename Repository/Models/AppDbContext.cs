using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiAdminEmpleado> ApiAdminEmpleados { get; set; }

    public virtual DbSet<ApiAuthUsuario> ApiAuthUsuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiAdminEmpleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ApiAdmin_Empleados");

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

        modelBuilder.Entity<ApiAuthUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ApiAuth_Usuarios");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CodigoRh)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CodigoRH");
            entity.Property(e => e.CodigoValidacion)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Contrasenna)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ExpiracionCodigo).HasColumnType("datetime");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
