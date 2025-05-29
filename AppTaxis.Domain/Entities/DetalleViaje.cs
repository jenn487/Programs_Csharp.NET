using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class DetalleViaje : BaseEntity
    {
        public DateTime Fecha {  get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int IdViaje {  get; set; } 
    }
}
