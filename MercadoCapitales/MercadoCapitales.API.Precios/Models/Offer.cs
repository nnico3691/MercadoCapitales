using System;

namespace MercadoCapitales.API.Precios.Models
{
    public class Offer
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public Guid MarketDataId { get; set; }
        public virtual MarketData MarketData { get; set; }
    }
}
