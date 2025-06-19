using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxis.Application.DTOs
{
    public class ViajeDTO
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public string? Calificacion { get; set; }
        public int IdTaxi { get; set; }
        public int IdUsuario { get; set; }
        public TaxiDTO? Taxi { get; set; }
        public UsuarioDTO? Usuario { get; set; }
        public bool EstaActivo => FechaFin == null;
        public TimeSpan? Duracion => FechaFin?.Subtract(FechaInicio);
    }

    public class CreateViajeDTO
    {
        public DateTime FechaInicio { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public int IdTaxi { get; set; }
        public int IdUsuario { get; set; }
    }

    public class UpdateViajeDTO
    {
        public int Id { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Calificacion { get; set; }
    }

    public class FinalizarViajeDTO
    {
        public int Id { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Calificacion { get; set; }
    }
}