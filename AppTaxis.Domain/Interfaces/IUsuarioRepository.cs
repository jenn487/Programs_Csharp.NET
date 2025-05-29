using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task InsertarUsuarioAsync(Usuario usuario);
        Task ActualizarUsuarioAsync(Usuario usuario);
        Task EliminarUsuarioAsync(int id);
    }
}
