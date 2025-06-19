using System.ComponentModel.DataAnnotations;
using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string? Documento { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string? Apellido { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
        public virtual ICollection<GrupoUsuariosDetalle> GrupoUsuariosDetalles { get; set; } = new List<GrupoUsuariosDetalle>();
    }
}
