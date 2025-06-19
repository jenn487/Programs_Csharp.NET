
namespace AppTaxis.Application.DTOs
{
    public class TaxiDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
    }

    public class CreateTaxiDTO
    {
        public string Placa { get; set; }
    }

    public class UpdateTaxiDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
    }
}
