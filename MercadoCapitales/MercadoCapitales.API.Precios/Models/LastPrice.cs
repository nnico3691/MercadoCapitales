using System;

namespace MercadoCapitales.API.Precios.Models
{
    public class LastPrice
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; } // Precio
        public decimal Size { get; set; } // Tamaño
        public long Date { get; set; } // Fecha en milisegundos desde la época Unix
        public Guid MarketDataId { get; set; }
        public virtual MarketData MarketData { get; set; }
    }
}
