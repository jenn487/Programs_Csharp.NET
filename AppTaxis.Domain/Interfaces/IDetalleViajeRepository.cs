using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IDetalleViajeRepository : IGenericRepository<DetalleViaje>
    {
        Task<IEnumerable<DetalleViaje>> GetDetallesByViajeAsync(int viajeId);
        Task<IEnumerable<DetalleViaje>> GetDetallesByFechaAsync(DateTime fecha);
        Task<DetalleViaje> GetUltimaUbicacionAsync(int viajeId);
    }
}
