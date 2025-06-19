using AppTaxis.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppTaxis.Persistence.Configurations
{
    public class ViajeConfiguration : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(EntityTypeBuilder<Viaje> builder)
        {
            builder.ToTable("Viaje");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(v => v.FechaInicio)
                .HasColumnName("FechaInicio")
                .IsRequired();

            builder.Property(v => v.FechaFin)
                .HasColumnName("FechaFin");

            builder.Property(v => v.Desde)
                .HasColumnName("Desde")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(v => v.Hasta)
                .HasColumnName("Hasta")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(v => v.Calificacion)
                .HasColumnName("Calificacion")
                .HasColumnType("CHAR(1)");

            builder.Property(v => v.IdTaxi)
                .HasColumnName("IdTaxi")
                .IsRequired();

            builder.Property(v => v.IdUsuario)
                .HasColumnName("IdUsuario")
                .IsRequired();

            // Foreign Keys
            builder.HasOne(v => v.Taxi)
                .WithMany(t => t.Viajes)
                .HasForeignKey(v => v.IdTaxi)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Usuario)
                .WithMany(u => u.Viajes)
                .HasForeignKey(v => v.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
