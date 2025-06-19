using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface ITaxiRepository : IGenericRepository <Taxi>
    {
        Task<Taxi> GetByPlacaAsync(string placa);
        Task<bool> PlacaExistsAsync(string placa);
        Task<IEnumerable<Taxi>> GetTaxisWithViajesAsync();
    }
}
