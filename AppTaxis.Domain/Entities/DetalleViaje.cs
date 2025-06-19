using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class DetalleViaje : BaseEntity
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,6)")]
        public decimal Latitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,6)")]
        public decimal Longitude { get; set; }

        [Required]
        public int IdViaje { get; set; }
        public virtual Viaje Viaje { get; set; }
    }
}
