using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class Taxi : BaseEntity
    {
        public string? Placa { get; set; }
    }
}
