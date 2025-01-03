using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primary.Data.PrimaryRiskAPI
{
    public class Position
    {
        [JsonProperty("instrument")]
        public Instrument Instrument { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("buySize")]
        public decimal BuySize { get; set; }

        [JsonProperty("buyPrice")]
        public decimal BuyPrice { get; set; }

        [JsonProperty("sellSize")]
        public decimal SellSize { get; set; }

        [JsonProperty("sellPrice")]
        public decimal SellPrice { get; set; }

        [JsonProperty("totalDailyDiff")]
        public decimal TotalDailyDiff { get; set; }

        [JsonProperty("totalDiff")]
        public decimal TotalDiff { get; set; }

        [JsonProperty("tradingSymbol")]
        public string TradingSymbol { get; set; }
    }
}
