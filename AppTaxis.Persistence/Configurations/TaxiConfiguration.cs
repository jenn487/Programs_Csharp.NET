using AppTaxis.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppTaxis.Persistence.Configurations
{
    public class TaxiConfiguration : IEntityTypeConfiguration<Taxi>
    {
        public void Configure(EntityTypeBuilder<Taxi> builder)
        {
            builder.ToTable("Taxi");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Placa)
                .HasColumnName("Placa")
                .HasMaxLength(10)
                .IsRequired();

            builder.HasIndex(t => t.Placa)
                .IsUnique();
        }
    }
}
