using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ArmediaTest.DAL.Entities;

namespace ArmediaTest.DAL.Context
{
    public partial class DbTestContext : DbContext
    {
        public DbTestContext()
        {
        }

        public DbTestContext(DbContextOptions<DbTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TRol> TRols { get; set; } = null!;
        public virtual DbSet<TUser> TUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=myserver809.database.windows.net;database=TestCrud;user=admin809;password=azure@2022*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TRol>(entity =>
            {
                entity.HasKey(e => e.CodRol)
                    .HasName("PK__tRol__F13B1211035FB3B9");

                entity.ToTable("tRol");

                entity.HasIndex(e => e.TxtDesc, "UQ__tRol__A097F0B62AD117CC")
                    .IsUnique();

                entity.Property(e => e.CodRol).HasColumnName("cod_rol");

                entity.Property(e => e.SnActivo)
                    .IsRequired()
                    .HasColumnName("sn_activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TxtDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("txt_desc");
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PK__tUsers__EA3C9B1A2956613F");

                entity.ToTable("tUsers");

                entity.HasIndex(e => new { e.TxtUser, e.NroDoc }, "UQ__tUsers__CE6A495C4C7969C3")
                    .IsUnique();

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.CodRol).HasColumnName("cod_rol");

                entity.Property(e => e.NroDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nro_doc");

                entity.Property(e => e.SnActivo)
                    .IsRequired()
                    .HasColumnName("sn_activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TxtApellido)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("txt_apellido");

                entity.Property(e => e.TxtNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("txt_nombre");

                entity.Property(e => e.TxtPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txt_password");

                entity.Property(e => e.TxtUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txt_user");

                entity.HasOne(d => d.CodRolNavigation)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.CodRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
