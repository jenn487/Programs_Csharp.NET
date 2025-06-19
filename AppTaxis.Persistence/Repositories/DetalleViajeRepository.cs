using AppTaxis.Domain.Entities;
using AppTaxis.Domain.Interfaces;
using AppTaxis.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppTaxis.Persistence.Repositories
{
    public class DetalleViajeRepository : GenericRepository<DetalleViaje>, IDetalleViajeRepository
    {
        public DetalleViajeRepository(AppTaxiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DetalleViaje>> GetDetallesByViajeAsync(int viajeId)
        {
            return await _dbSet
                .Include(d => d.Viaje)
                .Where(d => d.IdViaje == viajeId)
                .OrderBy(d => d.Fecha)
                .ToListAsync();
        }

        public async Task<IEnumerable<DetalleViaje>> GetDetallesByFechaAsync(DateTime fecha)
        {
            return await _dbSet
                .Include(d => d.Viaje)
                .Where(d => d.Fecha.Date == fecha.Date)
                .ToListAsync();
        }

        public async Task<DetalleViaje> GetUltimaUbicacionAsync(int viajeId)
        {
            return await _dbSet
                .Where(d => d.IdViaje == viajeId)
                .OrderByDescending(d => d.Fecha)
                .FirstOrDefaultAsync();
        }
    }
}