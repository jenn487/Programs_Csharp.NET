using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Entities;
using AppTaxis.Domain.Interfaces;
using AppTaxis.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppTaxis.Persistence.Repositories
{
    public class ViajeRepository : GenericRepository<Viaje>, IViajeRepository
    {
        public ViajeRepository(AppTaxiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Viaje>> GetViajesByUsuarioAsync(int usuarioId)
        {
            return await _dbSet
                .Include(v => v.Taxi)
                .Include(v => v.Usuario)
                .Where(v => v.IdUsuario == usuarioId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Viaje>> GetViajesByTaxiAsync(int taxiId)
        {
            return await _dbSet
                .Include(v => v.Taxi)
                .Include(v => v.Usuario)
                .Where(v => v.IdTaxi == taxiId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Viaje>> GetViajesByFechaAsync(DateTime fecha)
        {
            return await _dbSet
                .Include(v => v.Taxi)
                .Include(v => v.Usuario)
                .Where(v => v.FechaInicio.Date == fecha.Date)
                .ToListAsync();
        }

        public async Task<Viaje> GetViajeWithDetallesAsync(int viajeId)
        {
            return await _dbSet
                .Include(v => v.Taxi)
                .Include(v => v.Usuario)
                .Include(v => v.DetalleViajes)
                .FirstOrDefaultAsync(v => v.Id == viajeId);
        }

        public async Task<IEnumerable<Viaje>> GetViajesActivosAsync()
        {
            return await _dbSet
                .Include(v => v.Taxi)
                .Include(v => v.Usuario)
                .Where(v => v.FechaFin == null)
                .ToListAsync();
        }
    }
}