using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxis.Domain.Entities
{
    public  class Viaje
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set;}
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public char Calificacion {  get; set; }
        public int IdTaxi { get; set; }
        public int IdUsuario { get; set; }
    }
}
