using AppTaxis.Application.Interfaces;
using AppTaxis.Domain.Entities;
using AppTaxis.Domain.Interfaces;

namespace AppTaxis.Application.Services
{
    public class TaxiService 
    {
        private readonly ITaxiRepository _taxiRepo;

        public TaxiService(ITaxiRepository taxiRepo)
        {
            _taxiRepo = taxiRepo;
        }

        public async Task<IEnumerable<Taxi>> GetAllTaxisAsync() => await _taxiRepo.GetAllAsync();
        public async Task<Taxi> GetTaxiByIdAsync(int id) => await _taxiRepo.GetByIdAsync(id);
        public async Task AddTaxiAsync(Taxi taxi) => await _taxiRepo.AddAsync(taxi);
        public async Task UpdateTaxiAsync(Taxi taxi) => await _taxiRepo.UpdateAsync(taxi);
        public async Task DeleteTaxiAsync(int id) => await _taxiRepo.DeleteAsync(id);
    }
}