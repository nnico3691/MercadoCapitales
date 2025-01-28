namespace MercadoCapitales.API.Precios.Models.Dto
{
    public class SettlementDto
    {
        public decimal Price { get; set; }
        public long Date { get; set; } // Fecha en milisegundos
    }
}
