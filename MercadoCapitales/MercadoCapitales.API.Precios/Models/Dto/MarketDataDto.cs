using System;
using System.Collections.Generic;

namespace MercadoCapitales.API.Precios.Models.Dto
{
    public class MarketDataDto
    {
        public string Market { get; set; } // Mercado de la Especie
        public string Symbol { get; set; } // Simbolo de la Especie
        public decimal? ACP { get; set; } // Average Closing Price
        public List<BidDto> BI { get; set; } // Bid
        public decimal? CL { get; set; } // Closing Price
        public int EV { get; set; } // Exchange Volume
        public decimal? HI { get; set; } // High Price
        public decimal? IV { get; set; } // Intraday High Price
        public LastPriceDto LA { get; set; } // Last Price
        public decimal? LO { get; set; } // Low Price
        public int NV { get; set; } // Net Volume
        public List<OfferDto> OF { get; set; } // Offer
        public OpenInterestDto OI { get; set; } // Open Interest
        public decimal? OP { get; set; } // Opening Price
        public SettlementDto SE { get; set; } // Settlement
        public int TV { get; set; } // Total Volume
        public long Timestamp { get; set; } // Timestamp en milisegundos
        public string Type { get; set; } //Market Data
    }
}
