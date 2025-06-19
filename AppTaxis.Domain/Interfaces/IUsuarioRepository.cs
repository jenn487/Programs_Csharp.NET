using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByDocumentoAsync(string documento);
        Task<bool> DocumentoExistsAsync(string documento);
        Task<IEnumerable<Usuario>> GetUsuariosWithViajesAsync();
        Task<IEnumerable<Usuario>> GetUsuariosByGrupoAsync(int grupoId);
    }
}
