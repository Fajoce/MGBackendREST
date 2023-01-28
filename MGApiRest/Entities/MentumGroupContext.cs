using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MGApiRest.Entities
{
    public partial class MentumGroupContext : DbContext
    {
        public MentumGroupContext()
        {
        }

        public MentumGroupContext(DbContextOptions<MentumGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mgcliente> Mgcliente { get; set; }
        public virtual DbSet<Mgcontacto> Mgcontacto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mgcliente>(entity =>
            {
                entity.HasKey(e => e.CliId)
                    .HasName("PK__MGClient__FA1E289BB17EFE02");

                entity.ToTable("MGCliente");

                entity.Property(e => e.CliDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CliFechaCreacion).HasColumnType("date");

                entity.Property(e => e.CliIdentificacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CliNombreCompleto)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CliTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.CliContacto)
                    .WithMany(p => p.Mgcliente)
                    .HasForeignKey(d => d.CliContactoId)
                    .HasConstraintName("FK__MGCliente__CliCo__38996AB5");
            });

            modelBuilder.Entity<Mgcontacto>(entity =>
            {
                entity.HasKey(e => e.ConId)
                    .HasName("PK__MGContac__E19F47C9230B5902");

                entity.ToTable("MGContacto");

                entity.Property(e => e.ConDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConFechaCreacion).HasColumnType("date");

                entity.Property(e => e.ConIdentificacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ConNombreCompleto)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ConTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
