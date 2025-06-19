using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Application.Common;
using AppTaxis.Application.DTOs;
using AppTaxis.Domain.Entities;

namespace AppTaxis.Application.Interfaces
{
    public interface ITaxiService
    {
        Task<ApiResponse<IEnumerable<TaxiDTO>>> GetAllAsync();
        Task<ApiResponse<TaxiDTO>> GetByIdAsync(int id);
        Task<ApiResponse<TaxiDTO>> GetByPlacaAsync(string placa);
        Task<ApiResponse<TaxiDTO>> CreateAsync(CreateTaxiDTO createTaxiDto);
        Task<ApiResponse<TaxiDTO>> UpdateAsync(UpdateTaxiDTO updateTaxiDto);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<TaxiDTO>>> GetTaxisWithViajesAsync();
        Task<IEnumerable<Taxi>> GetAllTaxisAsync();
        Task<Taxi> GetTaxiByIdAsync(int id);
        Task AddTaxiAsync(Taxi taxi);
        Task UpdateTaxiAsync(Taxi taxi);
        Task DeleteTaxiAsync(int id);
    }
}