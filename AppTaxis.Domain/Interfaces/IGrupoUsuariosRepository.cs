using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IGrupoUsuariosRepository : IGenericRepository<GrupoUsuarios>
    {
        Task<GrupoUsuarios> GetGrupoWithUsuariosAsync(int grupoId);
        Task<IEnumerable<GrupoUsuarios>> GetGruposWithUsuariosAsync();
    }
}
