namespace GestorMercadoCapitales.Models
{
    public class Orden
    {
        public string Symbol { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string Side { get; set; }
        

    }
}
