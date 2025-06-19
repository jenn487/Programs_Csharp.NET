using AppTaxis.Application.Common;
using AppTaxis.Application.DTOs;

namespace AppTaxis.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<ApiResponse<IEnumerable<UsuarioDTO>>> GetAllAsync();
        Task<ApiResponse<UsuarioDTO>> GetByIdAsync(int id);
        Task<ApiResponse<UsuarioDTO>> GetByDocumentoAsync(string documento);
        Task<ApiResponse<UsuarioDTO>> CreateAsync(CreateUsuarioDTO createUsuarioDto);
        Task<ApiResponse<UsuarioDTO>> UpdateAsync(UpdateUsuarioDTO updateUsuarioDto);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<UsuarioDTO>>> GetUsuariosWithViajesAsync();
        Task<ApiResponse<IEnumerable<UsuarioDTO>>> GetUsuariosByGrupoAsync(int grupoId);
    }
}