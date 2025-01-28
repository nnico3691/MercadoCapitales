using MediatR;
using MercadoCapitales.API.Precios.Models.Dto;
using System.Collections.Generic;

namespace MercadoCapitales.API.Precios.Aplicacion.MarketData.Queries
{
    public class GetAllMarketDataQuery : IRequest<List<MarketDataDto>>
    {
        public GetAllMarketDataQuery()
        {

        }
    }
}
