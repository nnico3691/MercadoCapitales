using Primary.Data.Orders;
using System;

namespace MercadoCapitales.API.Ordenes.Models
{
    public class OrderStatus
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string ExecutionId { get; set; }
        public DateTime TransactionTime { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal LastPrice { get; set; }
        public uint LastQuantity { get; set; }
        public uint CumulativeQuantity { get; set; }
        public uint LeavesQuantity { get; set; }
        public Status Status { get; set; }
        public string StatusText { get; set; }
        public Guid OrdenId { get; set; } // Este será el Id de la orden a la que pertenece
        public virtual Order Orden { get; set; }
    }
}
