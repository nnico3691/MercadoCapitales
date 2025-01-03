using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primary.Data.PrimaryRiskAPI
{
    public class Instrument
    {
        [JsonProperty("symbolReference")]
        public string SymbolReference { get; set; }

        [JsonProperty("settlType")]
        public int SettType { get; set; }
    }
}
