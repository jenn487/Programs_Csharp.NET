using AppTaxis.Domain.Entities;
using AppTaxis.Domain.Interfaces;
using AppTaxis.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppTaxis.Persistence.Repositories
{
    public class TaxiRepository : GenericRepository<Taxi>, ITaxiRepository
    {
        public TaxiRepository(AppTaxiContext context) : base(context)
        {
        }

        public async Task<Taxi> GetByPlacaAsync(string placa)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Placa == placa);
        }

        public async Task<bool> PlacaExistsAsync(string placa)
        {
            return await _dbSet.AnyAsync(t => t.Placa == placa);
        }

        public async Task<IEnumerable<Taxi>> GetTaxisWithViajesAsync()
        {
            return await _dbSet.Include(t => t.Viajes).ToListAsync();
        }
    }
}