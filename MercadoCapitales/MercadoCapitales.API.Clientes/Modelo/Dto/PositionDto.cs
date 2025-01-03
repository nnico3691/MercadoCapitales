using System;

namespace MercadoCapitales.API.Clientes.Modelo.Dto
{
    public class PositionDto
    {
        public Guid InstrumentId { get; set; }
        public string Symbol { get; set; }
        public int BuySize { get; set; }
        public decimal BuyPrice { get; set; }
        public int SellSize { get; set; }
        public decimal SellPrice { get; set; }
        public decimal TotalDailyDiff { get; set; }
        public decimal TotalDiff { get; set; }
        public string TradingSymbol { get; set; }
        public Guid PrimaryUserId { get; set; } 
    }
}
