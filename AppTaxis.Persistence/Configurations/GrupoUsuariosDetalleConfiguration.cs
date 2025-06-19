using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppTaxis.Persistence.Configurations
{
    public class GrupoUsuariosDetalleConfiguration : IEntityTypeConfiguration<GrupoUsuariosDetalle>
    {
        public void Configure(EntityTypeBuilder<GrupoUsuariosDetalle> builder)
        {
            builder.ToTable("GrupoUsuariosDetalle");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(g => g.IdGrupoUsuarios)
                .HasColumnName("IdGrupoUsuarios")
                .IsRequired();

            builder.Property(g => g.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            // Foreign Keys
            builder.HasOne(g => g.GrupoUsuarios)
                .WithMany(gu => gu.GrupoUsuariosDetalles)
                .HasForeignKey(g => g.IdGrupoUsuarios)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.Usuario)
                .WithMany(u => u.GrupoUsuariosDetalles)
                .HasForeignKey(g => g.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}