using Newtonsoft.Json;
using Primary.Data.Orders;
using System;

namespace GestorMercadoCapitales.Models
{
    public class OrderAll
    {
        public string id { get; set; }
        public Account account { get; set; }
        public string executionId { get; set; }
        public DateTime transactionTime { get; set; }
        public decimal averagePrice { get; set; }
        public decimal lastPrice { get; set; }
        public uint LastQuantity { get; set; }
        public uint CumulativeQuantity { get; set; }    
        public uint LeavesQuantity { get; set; }
        public string Status { get; set; }
        public string StatusText { get; set; }
        public string cancelPrevious { get; set; }
        public bool iceberg { get; set; }
        public uint DisplayQuantity { get; set; }
        public InstrumentId instrumentId { get; set; }
        public float price { get; set; }
        public uint quantity { get; set; }
        public uint type { get; set; }
        public uint side { get; set; }
        public uint expiration { get; set; }
        public DateTime expirationDate { get; set; }
        public string proprietary { get; set; }
        public string clientOrderId { get; set; }

    }

    public class Account
    { 
        public string id { get; set; }
    }

    public class InstrumentId
    {
        public string Market { get; set; }
        public string Symbol { get; set; }

    }
}
