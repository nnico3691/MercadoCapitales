using System;

namespace MercadoCapitales.API.Precios.Models
{
    public class Settlement
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public long Date { get; set; } // Fecha en milisegundos
        public Guid MarketDataId { get; set; }
        public virtual MarketData MarketData { get; set; }
    }
}
