using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IDetalleViajeRepository
    {
        Task InsertarDetalleViajeAsync(DetalleViaje detalleviaje);
        Task ActualizarDetalleViajeAsync(DetalleViaje detalleviaje);
        Task EliminarDetalleViajeAsync(int id);
    }
}
