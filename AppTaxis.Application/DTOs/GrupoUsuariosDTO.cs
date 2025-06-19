using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxis.Application.DTOs
{
    public class GrupoUsuariosDTO
    {
        public int Id { get; set; }
        public List<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
        public int CantidadUsuarios => Usuarios.Count;
    }

    public class CreateGrupoUsuariosDTO
    {
        public List<int> IdUsuarios { get; set; } = new List<int>();
    }
}