using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IGrupoUsuariosDetalleRepository
    {
        Task InsertarGrupoUsuariosDetalleAsync(GrupoUsuariosDetalle grupoUsuariosdetalle);
        Task ActualizarGrupoUsuariosDetalleAsync(GrupoUsuariosDetalle grupoUsuariosdetalle);
        Task EliminarGrupoUsuariosDetalleAsync(int id);
    }
}
