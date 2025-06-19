using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IGrupoUsuariosDetalleRepository : IGenericRepository<GrupoUsuariosDetalle>
    {
        Task<IEnumerable<GrupoUsuariosDetalle>> GetByGrupoAsync(int grupoId);
        Task<IEnumerable<GrupoUsuariosDetalle>> GetByUsuarioAsync(int usuarioId);
        Task<bool> UsuarioEnGrupoAsync(int usuarioId, int grupoId);
        Task<bool> RemoveUsuarioFromGrupoAsync(int usuarioId, int grupoId);
    }
}
