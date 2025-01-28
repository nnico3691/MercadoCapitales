using System.ComponentModel.DataAnnotations;
using System;
using System.Text;
using System.Collections.Generic;

namespace MercadoCapitales.API.Especies.Models
{
    public class Instrument
    {
        [Key]
        public Guid Id { get; set; }
        public string Market { get; set; }
        public string Symbol { get; set; }
        public string MarketSegmentId { get; set; }
        public string marketId { get; set; }
        public float lowLimitPrice { get; set; }
        public float highLimitPrice { get; set; }
        public float minPriceIncrement { get; set; }
        public float minTradeVol { get; set; }
        public float maxTradeVol { get; set; }
        public float tickSize { get; set; }
        public float contractMultiplier { get; set; }
        public float roundLot { get; set; }
        public float PriceConversionFactor { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string Currency { get; set; }
        public string securityType { get; set; }
        public string settlType { get; set; }
        public string instrumentPricePrecision { get; set; }
        public string instrumentSizePrecision { get; set; }
        public string securityId { get; set; }
        public string securityIdSource { get; set; }
        public string Description { get; set; }
        public string cficode { get; set; }
        public List<InstrumentOrderType>? InstrumentOrderType { get; set; }
        public List<InstrumentTimeInForce>? InstrumentTimeInForce { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }

    }
}
