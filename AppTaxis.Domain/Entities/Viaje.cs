using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxis.Domain.Entities
{
    public  class Viaje
    {
        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [Required]
        [StringLength(100)]
        public string? Desde { get; set; }

        [Required]
        [StringLength(100)]
        public string? Hasta { get; set; }

        [StringLength(1)]
        public string? Calificacion { get; set; }

        [Required]
        public int IdTaxi { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        public virtual Taxi? Taxi { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<DetalleViaje> DetalleViajes { get; set; } = new List<DetalleViaje>();
    }
}
