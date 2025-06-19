using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxis.Application.DTOs
{
    public class DetalleViajeDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int IdViaje { get; set; }
        public ViajeDTO? Viaje { get; set; }
    }

    public class CreateDetalleViajeDTO
    {
        public DateTime Fecha { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int IdViaje { get; set; }
    }

    public class UpdateDetalleViajeDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class UbicacionDTO
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Fecha { get; set; }
    }
}

