using AppTaxis.Domain.Base;

namespace AppTaxis.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
