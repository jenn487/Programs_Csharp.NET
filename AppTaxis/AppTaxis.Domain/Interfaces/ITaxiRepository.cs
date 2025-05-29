using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface ITaxiRepository
    {
        Task InsertarTaxiAsync(Taxi taxi);
        Task ActualizarTaxiAsync(Taxi taxi);
        Task EliminarTaxiAsync(int id);
    }
}
