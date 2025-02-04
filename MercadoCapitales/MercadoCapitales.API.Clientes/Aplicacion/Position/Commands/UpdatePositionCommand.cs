using MediatR;
using MercadoCapitales.API.Clientes.Models;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Commands
{
    public class UpdatePositionCommand : IRequest<bool>
    {
        public Guid Id { get; set; } // Cambiado a Guid para coincidir con la entidad
        public Guid InstrumentId { get; set; } // Información del instrumento
        public string Symbol { get; set; } // Símbolo de la posición
        public int BuySize { get; set; } // Tamaño de compra
        public decimal BuyPrice { get; set; } // Precio de compra
        public int SellSize { get; set; } // Tamaño de venta
        public decimal SellPrice { get; set; } // Precio de venta
        public decimal TotalDailyDiff { get; set; } // Diferencia total diaria
        public decimal TotalDiff { get; set; } // Diferencia total
        public string TradingSymbol { get; set; } // Símbolo de trading

        // Agrega más propiedades según sea necesario
    }
}
