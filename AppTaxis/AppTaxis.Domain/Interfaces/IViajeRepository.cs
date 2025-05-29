using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Entities;

namespace AppTaxis.Domain.Interfaces
{
    public interface IViajeRepository
    {
        Task InsertarViajeAsync(Viaje viaje);
        Task ActualizarViajeAsync(Viaje viaje);
        Task EliminarViajeAsync(int id);
    }
}
