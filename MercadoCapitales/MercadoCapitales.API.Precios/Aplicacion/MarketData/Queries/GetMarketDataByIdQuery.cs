using MediatR;
using MercadoCapitales.API.Precios.Models.Dto;
using System;

namespace MercadoCapitales.API.Precios.Aplicacion.MarketData.Queries
{
    public class GetMarketDataByIdQuery : IRequest<MarketDataDto>
    {
        public Guid Id { get; set; }
    }
}
