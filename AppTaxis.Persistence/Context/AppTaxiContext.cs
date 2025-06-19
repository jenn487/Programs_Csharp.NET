using Microsoft.EntityFrameworkCore;
using AppTaxis.Domain.Entities;
using AppTaxis.Persistence.Configurations;

namespace AppTaxis.Persistence.Context
{
    public class AppTaxiContext : DbContext
    {
        public AppTaxiContext(DbContextOptions<AppTaxiContext> options) : base(options)
        {
        }

        public DbSet<Taxi> Taxis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<DetalleViaje> DetalleViajes { get; set; }
        public DbSet<GrupoUsuarios> GrupoUsuarios { get; set; }
        public DbSet<GrupoUsuariosDetalle> GrupoUsuariosDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaxiConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ViajeConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleViajeConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoUsuariosConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoUsuariosDetalleConfiguration());
        }
    }
}
