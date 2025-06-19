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
    public class DetalleViajeConfiguration : IEntityTypeConfiguration<DetalleViaje>
    {
        public void Configure(EntityTypeBuilder<DetalleViaje> builder)
        {
            builder.ToTable("DetalleViaje");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Fecha)
                .HasColumnName("Fecha")
                .IsRequired();

            builder.Property(d => d.Latitude)
                .HasColumnName("Latitude")
                .HasColumnType("decimal(9,6)")
                .IsRequired();

            builder.Property(d => d.Longitude)
                .HasColumnName("Longitude")
                .HasColumnType("decimal(9,6)")
                .IsRequired();

            builder.Property(d => d.IdViaje)
                .HasColumnName("IdViaje")
                .IsRequired();

            // Foreign Key
            builder.HasOne(d => d.Viaje)
                .WithMany(v => v.DetalleViajes)
                .HasForeignKey(d => d.IdViaje)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
