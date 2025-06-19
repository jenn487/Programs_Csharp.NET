using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Application.Common;
using AppTaxis.Application.DTOs;

namespace AppTaxis.Application.Interfaces
{
    public interface IGrupoUsuariosDetalleService
    {
        Task<ApiResponse<IEnumerable<GrupoUsuariosDetalleDTO>>> GetAllAsync();
        Task<ApiResponse<GrupoUsuariosDetalleDTO>> GetByIdAsync(int id);
        Task<ApiResponse<GrupoUsuariosDetalleDTO>> CreateAsync(CreateGrupoUsuariosDetalleDTO createGrupoUsuariosDetalleDto);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<GrupoUsuariosDetalleDTO>>> GetByGrupoAsync(int grupoId);
        Task<ApiResponse<IEnumerable<GrupoUsuariosDetalleDTO>>> GetByUsuarioAsync(int usuarioId);
        Task<ApiResponse<GrupoUsuariosDetalleDTO>> AgregarUsuarioGrupoAsync(AgregarUsuarioGrupoDTO agregarUsuarioGrupoDto);
        Task<ApiResponse> RemoverUsuarioGrupoAsync(int usuarioId, int grupoId);
    }
}