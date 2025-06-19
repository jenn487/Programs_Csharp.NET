using System.ComponentModel.DataAnnotations;
using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class Taxi : BaseEntity
    {
        [Required]
        [StringLength(10)]
        public string? Placa { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
    }
}
