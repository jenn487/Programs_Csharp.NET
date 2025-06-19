using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Application.Common;
using AppTaxis.Application.DTOs;

namespace AppTaxis.Application.Interfaces
{
    public interface IDetalleViajeService
    {
        Task<ApiResponse<IEnumerable<DetalleViajeDTO>>> GetAllAsync();
        Task<ApiResponse<DetalleViajeDTO>> GetByIdAsync(int id);
        Task<ApiResponse<DetalleViajeDTO>> CreateAsync(CreateDetalleViajeDTO createDetalleViajeDto);
        Task<ApiResponse<DetalleViajeDTO>> UpdateAsync(UpdateDetalleViajeDTO updateDetalleViajeDto);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<DetalleViajeDTO>>> GetDetallesByViajeAsync(int viajeId);
        Task<ApiResponse<IEnumerable<DetalleViajeDTO>>> GetDetallesByFechaAsync(DateTime fecha);
        Task<ApiResponse<DetalleViajeDTO>> GetUltimaUbicacionAsync(int viajeId);
        Task<ApiResponse<DetalleViajeDTO>> AgregarUbicacionAsync(int viajeId, UbicacionDTO ubicacion);
    }
}