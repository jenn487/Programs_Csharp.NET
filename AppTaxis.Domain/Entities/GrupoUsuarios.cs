using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class GrupoUsuarios : BaseEntity
    {
        public virtual ICollection<GrupoUsuariosDetalle> GrupoUsuariosDetalles { get; set; } = new List<GrupoUsuariosDetalle>();
    }
}
