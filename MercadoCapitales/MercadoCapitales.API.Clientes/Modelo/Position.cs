using System;

namespace MercadoCapitales.API.Clientes.Modelo
{
    public class Position
    {
        public Guid Id { get; set; }
        public Guid InstrumentId { get; set; }
        public string Symbol { get; set; }
        public decimal BuySize { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellSize { get; set; }
        public decimal SellPrice { get; set; }
        public decimal TotalDailyDiff { get; set; }
        public decimal TotalDiff { get; set; }
        public string TradingSymbol { get; set; }

        // Nueva propiedad para referenciar al PrimaryUser
        public Guid PrimaryUserId { get; set; } // Clave foránea para el usuario
        public virtual PrimaryUser PrimaryUser { get; set; } // Navegación a la entidad PrimaryUser
    }
}
