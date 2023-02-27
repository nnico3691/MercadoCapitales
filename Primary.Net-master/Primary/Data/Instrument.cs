using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Primary.Serialization;
using System;
using System.Collections.Generic;

namespace Primary.Data
{
    /// <summary>Identifies a market instrument.</summary>
    [JsonConverter(typeof(JsonPathDeserializer))]
    public class Segment
    {
        [JsonProperty("marketSegmentId")]
        public string MarketSegmentId { get; set; }

        [JsonProperty("marketId")]
        public string marketId { get; set; }
    }

    /// <summary>Identifies a market instrument.</summary>
    [JsonConverter(typeof(JsonPathDeserializer))]
    public class InstrumentId
    {
        /// <remarks>Only accepted value is **ROFX**.</remarks>
        [JsonProperty("marketId")]
        public string Market { get; set; }

        /// <summary>Ticker of the instrument.</summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        #region JSON serialization

        [JsonProperty("instrumentId.marketId")]
        protected string NestedMarket { get { return Market; } set { Market = value; } }

        [JsonProperty("instrumentId.symbol")]
        protected string NestedSymbol { get { return Symbol; } set { Symbol = value; } }

        /// <summary>This is used for serialization purposes and should not be called.</summary>
        public bool ShouldSerializeNestedMarket() { return false; }

        /// <summary>This is used for serialization purposes and should not be called.</summary>
        public bool ShouldSerializeNestedSymbol() { return false; }

        #endregion
    }

    //[JsonConverter(typeof(JsonPathDeserializer))]
    public class Instrument : InstrumentId
    {
        [JsonProperty("segment")]
        public Segment segment { get; set; }

        /// <summary> lowLimitPrice
        /// </summary>
        [JsonProperty("lowLimitPrice")]
        public float lowLimitPrice { get; set; }

        /// <summary> highLimitPrice
        /// </summary>
        [JsonProperty("highLimitPrice")]
        public float highLimitPrice { get; set; }

        /// <summary> minPriceIncrement
        /// </summary>
        [JsonProperty("minPriceIncrement")]
        public float minPriceIncrement { get; set; }

        /// <summary> minTradeVol
        /// </summary>
        [JsonProperty("minTradeVol")]
        public float minTradeVol { get; set; }

        /// <summary> maxTradeVol
        /// </summary>
        [JsonProperty("maxTradeVol")]
        public float maxTradeVol { get; set; }

        /// <summary> tickSize
        /// </summary>
        [JsonProperty("tickSize")]
        public float tickSize { get; set; }

        /// <summary> contractMultiplier
        /// </summary>
        [JsonProperty("contractMultiplier")]
        public float contractMultiplier { get; set; }

        /// <summary> roundLot
        /// </summary>
        [JsonProperty("roundLot")]
        public float roundLot { get; set; }

        /// <summary>Price multiplier to get the price for a single unit.
        /// For example, if an instrument is traded in lots of 100, this value will be 0.01.
        /// </summary>
        [JsonProperty("priceConvertionFactor")]
        public float PriceConversionFactor { get; set; }

        /// <summary>Maturity date (if applicable).</summary>
        [JsonProperty("maturityDate")]
        [JsonConverter(typeof(FlatDateTimeJsonDeserializer))]
        public DateTime? MaturityDate { get; set; }

        /// <summary>Currency.</summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>orderTypes.</summary>
        [JsonProperty("orderTypes")]
        public List<string> orderTypes { get; set; }

        /// <summary>timesInForce.</summary>
        [JsonProperty("timesInForce")]
        public List<string> timesInForce { get; set; }

        [JsonProperty("securityType")]
        public string securityType { get; set; }

        [JsonProperty("settlType")]
        public string settlType { get; set; }

        [JsonProperty("instrumentPricePrecision")]
        public string instrumentPricePrecision { get; set; }

        [JsonProperty("instrumentSizePrecision")]
        public string instrumentSizePrecision { get; set; }

        [JsonProperty("securityId")]
        public string securityId { get; set; }

        [JsonProperty("securityIdSource")]
        public string securityIdSource { get; set; }

        /// <summary>Dezscription of the instrument.</summary>
        [JsonProperty("securityDescription")]
        public string Description { get; set; }

        [JsonProperty("cficode")]
        public string cficode { get; set; }
    }
}
