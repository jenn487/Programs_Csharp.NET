using System.Threading.Tasks;
using AppTaxis.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppTaxis.Persistence.Configurations
{
    public class GrupoUsuariosConfiguration : IEntityTypeConfiguration<GrupoUsuarios>
    {
        public void Configure(EntityTypeBuilder<GrupoUsuarios> builder)
        {
            builder.ToTable("GrupoUsuarios");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}