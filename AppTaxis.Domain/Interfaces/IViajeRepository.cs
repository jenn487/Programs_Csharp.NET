using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IViajeRepository : IGenericRepository<Viaje>
    {
        Task<IEnumerable<Viaje>> GetViajesByUsuarioAsync(int usuarioId);
        Task<IEnumerable<Viaje>> GetViajesByTaxiAsync(int taxiId);
        Task<IEnumerable<Viaje>> GetViajesByFechaAsync(DateTime fecha);
        Task<Viaje> GetViajeWithDetallesAsync(int viajeId);
        Task<IEnumerable<Viaje>> GetViajesActivosAsync();
    }
}
