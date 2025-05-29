using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IGrupoUsuariosRepository
    {
        Task InsertarGrupoUsuariosAsync(GrupoUsuarios grupousuarios);
        Task ActualizarGrupoUsuariosAsync(GrupoUsuarios grupousuarios);
        Task EliminarGrupoUsuariosAsync(int id);
    }
}
