using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Application.Common;
using AppTaxis.Application.DTOs;

namespace AppTaxis.Application.Interfaces
{
    public interface IViajeService
    {
        Task<ApiResponse<IEnumerable<ViajeDTO>>> GetAllAsync();
        Task<ApiResponse<ViajeDTO>> GetByIdAsync(int id);
        Task<ApiResponse<ViajeDTO>> CreateAsync(CreateViajeDTO createViajeDto);
        Task<ApiResponse<ViajeDTO>> UpdateAsync(UpdateViajeDTO updateViajeDto);
        Task<ApiResponse<ViajeDTO>> FinalizarViajeAsync(FinalizarViajeDTO finalizarViajeDto);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<ViajeDTO>>> GetViajesByUsuarioAsync(int usuarioId);
        Task<ApiResponse<IEnumerable<ViajeDTO>>> GetViajesByTaxiAsync(int taxiId);
        Task<ApiResponse<IEnumerable<ViajeDTO>>> GetViajesByFechaAsync(DateTime fecha);
        Task<ApiResponse<ViajeDTO>> GetViajeWithDetallesAsync(int viajeId);
        Task<ApiResponse<IEnumerable<ViajeDTO>>> GetViajesActivosAsync();
    }
}
