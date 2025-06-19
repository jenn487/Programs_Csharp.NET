using System.ComponentModel.DataAnnotations;
using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class GrupoUsuariosDetalle : BaseEntity
    {
        [Required]
        public int IdGrupoUsuarios { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        public virtual GrupoUsuarios GrupoUsuarios { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
