using MediatR;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Precios.Models.Dto;
using MercadoCapitales.API.Precios.Persistencia;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace MercadoCapitales.API.Precios.Aplicacion.MarketData.Queries
{
    public class GetMarketDataByIdQueryHandler : IRequestHandler<GetMarketDataByIdQuery, MarketDataDto>
    {
        private readonly Context _context; // O tu contexto de datos
        private readonly IMapper _mapper;

        public GetMarketDataByIdQueryHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MarketDataDto> Handle(GetMarketDataByIdQuery request, CancellationToken cancellationToken)
        {
            var marketData = await _context.MarketData
                .Include(md => md.BI)
                .Include(md => md.OF)
                .Include(md => md.OI)
                .Include(md => md.SE)
                .FirstOrDefaultAsync(md => md.Id == request.Id, cancellationToken);

            if (marketData == null)
            {
                throw new Exception("No se encontró el MarketData");
            }

            return _mapper.Map<MarketDataDto>(marketData);
        }
    }
}
