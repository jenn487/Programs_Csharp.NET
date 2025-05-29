using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class GrupoUsuariosDetalle : BaseEntity
    {
        public int IdGrupoUsuarios {  get; set; }
        public int IdUsuario { get; set; }
    }
}
