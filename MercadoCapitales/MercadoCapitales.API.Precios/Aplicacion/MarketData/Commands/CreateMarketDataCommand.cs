using MediatR;
using MercadoCapitales.API.Precios.Models;
using MercadoCapitales.API.Precios.Models.Dto;
using System;
using System.Collections.Generic;

namespace MercadoCapitales.API.Precios.Aplicacion.MarketData.Commands
{
    public class CreateMarketDataCommand : IRequest<Guid>
    {
        public MarketDataDto MarketData { get; set; }

        // Constructor sin parámetros para permitir la deserialización
        public CreateMarketDataCommand() { }

        // Constructor opcional para facilitar la creación del comando
        public CreateMarketDataCommand(MarketDataDto marketData)
        {
            MarketData = marketData;
        }

    }
}
