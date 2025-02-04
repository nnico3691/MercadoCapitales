using MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MercadoCapitales.API.Clientes.Persistencia;
using MercadoCapitales.API.Clientes.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Queries
{
    public class GetRecommendationByIdQueryHandler : IRequestHandler<GetRecommendationByIdQuery, RecommendationQueryDto>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;

        public GetRecommendationByIdQueryHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecommendationQueryDto> Handle(GetRecommendationByIdQuery request, CancellationToken cancellationToken)
        {
            var recommendation = await _context.Recommendation
                .AsNoTracking()
                .FirstOrDefaultAsync(ae => ae.Id == request.Id, cancellationToken);

            if (recommendation == null)
                return null; // Manejar esto en el controlador con un 404

            return _mapper.Map<RecommendationQueryDto>(recommendation);
        }
    }
}
