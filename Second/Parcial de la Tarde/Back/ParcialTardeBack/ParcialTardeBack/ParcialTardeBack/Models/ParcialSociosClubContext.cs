using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParcialTardeBack.Models;

public partial class ParcialSociosClubContext : DbContext
{
    public ParcialSociosClubContext()
    {
    }

    public ParcialSociosClubContext(DbContextOptions<ParcialSociosClubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Socio> Socios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AOCWEI\\SQLEXPRESS;Initial Catalog=ParcialSociosClub;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Socio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SOCIOS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NombreDeporte)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_DEPORTE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
