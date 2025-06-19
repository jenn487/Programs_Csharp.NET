using AppTaxis.Application.Common;
using AppTaxis.Application.DTOs;

namespace AppTaxis.Application.Interfaces
{
    public interface IGrupoUsuariosService
    {
        Task<ApiResponse<IEnumerable<GrupoUsuariosDTO>>> GetAllAsync();
        Task<ApiResponse<GrupoUsuariosDTO>> GetByIdAsync(int id);
        Task<ApiResponse<GrupoUsuariosDTO>> CreateAsync(CreateGrupoUsuariosDTO createGrupoUsuariosDto);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse<GrupoUsuariosDTO>> GetGrupoWithUsuariosAsync(int grupoId);
        Task<ApiResponse<IEnumerable<GrupoUsuariosDTO>>> GetGruposWithUsuariosAsync();
    }
}
