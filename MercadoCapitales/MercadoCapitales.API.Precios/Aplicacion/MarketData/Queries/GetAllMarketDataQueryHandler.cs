using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Precios.Models.Dto;
using AutoMapper;
using MercadoCapitales.API.Precios.Persistencia;
using System;

namespace MercadoCapitales.API.Precios.Aplicacion.MarketData.Queries
{
    public class GetAllMarketDataQueryHandler : IRequestHandler<GetAllMarketDataQuery, List<MarketDataDto>>
{
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetAllMarketDataQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<MarketDataDto>> Handle(GetAllMarketDataQuery request, CancellationToken cancellationToken)
        {
            throw new Exception("An unexpected error occurred while retrieving positions.");
        }
    }

}


