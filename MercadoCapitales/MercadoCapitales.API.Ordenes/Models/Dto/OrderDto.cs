using MercadoCapitales.API.Ordenes.Models;
using System.Collections.Generic;
using System;
using Primary.Data.Orders;

namespace MercadoCapitales.API.Ordenes.Models.Dto
{
    public class OrderDto
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

        // Mercado de la Especie
        public string Market { get; set; }

        // Simbolo de la Especie
        public string Symbol { get; set; }

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
        public List<OrderStatusDto> StatusHistory { get; set; } = new List<OrderStatusDto>();
    }

    public class OrderStatusDto
    {
        // Identificador único del estado de la orden
        public Guid Id { get; set; }

        // Cuenta asociada al estado de la orden
        public string Account { get; set; }

        // Identificador de ejecución asociado al estado
        public string ExecutionId { get; set; }

        // Hora de la transacción
        public DateTime TransactionTime { get; set; }

        // Precio promedio de ejecución
        public decimal AveragePrice { get; set; }

        // Último precio registrado
        public decimal LastPrice { get; set; }

        // Última cantidad registrada en la transacción
        public uint LastQuantity { get; set; }

        // Cantidad acumulada hasta el momento
        public uint CumulativeQuantity { get; set; }

        // Cantidad restante por ejecutar
        public uint LeavesQuantity { get; set; }

        // Estado actual de la orden
        public Status Status { get; set; }

        // Texto descriptivo del estado
        public string StatusText { get; set; }
    }
}
