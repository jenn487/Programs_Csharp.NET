using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxis.Application.DTOs
{
    public class GrupoUsuariosDetalleDTO
    {
        public int Id { get; set; }
        public int IdGrupoUsuarios { get; set; }
        public int IdUsuario { get; set; }
        public GrupoUsuariosDTO? GrupoUsuarios { get; set; }
        public UsuarioDTO? Usuario { get; set; }
    }

    public class CreateGrupoUsuariosDetalleDTO
    {
        public int IdGrupoUsuarios { get; set; }
        public int IdUsuario { get; set; }
    }

    public class AgregarUsuarioGrupoDTO
    {
        public int IdGrupoUsuarios { get; set; }
        public int IdUsuario { get; set; }
    }
}