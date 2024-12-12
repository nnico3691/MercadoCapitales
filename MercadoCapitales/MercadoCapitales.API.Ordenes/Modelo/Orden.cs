using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;
using Primary.Data.Orders;
using System.Collections.Generic;

namespace MercadoCapitales.API.Ordenes.Modelo
{
    public class Orden
    {
        // Identificador único del pedido
        public Guid Id { get; set; }

        // Identificador propietario del pedido
        public string Proprietary { get; set; }

        // Identificador del pedido del cliente
        public string ClientOrderId { get; set; }

        // Indica si se debe cancelar un pedido anterior
        public bool CancelPrevious { get; set; }

        // Indica si el pedido es un iceberg (solo una parte visible)
        public bool Iceberg { get; set; }

        // Cantidad a mostrar en caso de ser un iceberg
        public uint DisplayQuantity { get; set; }

        // Identificador del instrumento relacionado con el pedido
        public InstrumentId InstrumentId { get; set; }

        // Precio del pedido, puede ser nulo
        public decimal? Price { get; set; }

        // Cantidad total del pedido
        public int Quantity { get; set; }

        // Tipo de orden (por ejemplo, mercado, límite, etc.)
        public Orders.Type Type { get; set; }

        // Lado de la orden (compra o venta)
        public Side Side { get; set; }

        // Expiración de la orden (si aplica)
        public Expiration Expiration { get; set; }

        // Fecha de expiración de la orden
        public DateTime ExpirationDate { get; set; }

        // Lista de estados asociados a la orden
        public List<OrderStatus> StatusHistory { get; set; } = new List<OrderStatus>();
    }

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
        public virtual Orden Orden { get; set; }
    }

    public class AccountId
    {
        public string Id { get; set; }
    }
    public class InstrumentId
    {
        public Guid Id { get; set; }
        public string Market { get; set; }
        public string Symbol { get; set; }
    }

    public static class Orders
    {
        public enum Type
        {
            Market,
            Limit,
            Stop,
            StopLimit,
            // Agregar otros tipos según sea necesario
        }
    }

    public enum Side
    {
        Buy,
        Sell,
    }

    public enum Expiration
    {
        GoodTillCancel,
        ImmediateOrCancel,
        FillOrKill,
    }

}
