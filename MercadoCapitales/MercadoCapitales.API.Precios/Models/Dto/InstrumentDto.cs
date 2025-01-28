using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercadoCapitales.API.Precios.Models.Dto
{
    public class InstrumentDto
    {
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
        public List<InstrumentOrderTypeDto>? InstrumentOrderType { get; set; }
        public List<InstrumentTimeInForceDto>? InstrumentTimeInForce { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
    public class InstrumentOrderTypeDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
    }
    public class InstrumentTimeInForceDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }

    }
}
