using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoCapitales.API.Precios.Models
{
    public class MarketData
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        //public Guid? InstrumentId { get; set; }
        public string Market { get; set; } // Mercado de la Especie
        public string Symbol { get; set; } // Simbolo de la Especie
        public decimal? ACP { get; set; } // Average Closing Price
        public List<Bid> BI { get; set; } // Bid
        public decimal? CL { get; set; } // Closing Price
        public int EV { get; set; } // Exchange Volume
        public decimal? HI { get; set; } // High Price
        public decimal? IV { get; set; } // Intraday High Price
        public LastPrice? LA { get; set; } // Last Price Object [Price,size, date]
        public decimal? LO { get; set; } // Low Price
        public int NV { get; set; } // Net Volume
        public List<Offer> OF { get; set; } // Offer
        public OpenInterest OI { get; set; } // Open Interest
        public decimal? OP { get; set; } // Opening Price
        public Settlement SE { get; set; } // Settlement
        public int TV { get; set; } // Total Volume
        public long Timestamp { get; set; } // Timestamp en milisegundos
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
    
}
