using AutoMapper;
using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using MercadoCapitales.API.Clientes.Persistencia;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MercadoCapitales.API.Clientes.Services;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Queries
{
    public class GetAllRecommendationQueryHandler : IRequestHandler<GetAllRecommendationQuery, List<RecommendationQueryDto>>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;
        private readonly IInstrumentService _instrumentService;

        public GetAllRecommendationQueryHandler(ContextCliente context, IMapper mapper, IInstrumentService instrumentService)
        {
            _context = context;
            _mapper = mapper;
            _instrumentService = instrumentService;
        }

        public async Task<List<RecommendationQueryDto>> Handle(GetAllRecommendationQuery request, CancellationToken cancellationToken)
        {
            var recommendations = await _context.Recommendation
                .Include(r => r.InvestmentRecommendation) // Incluir la relación
                .ToListAsync(cancellationToken);

            var instrumentos = await _instrumentService.GetAllInstrumentsAsync();

            // Mapeo manual de InvestmentRecommendation con InstrumentDto
            var recommendationQueryDtos = recommendations.Select(r => new RecommendationQueryDto
            {
                // Otras propiedades de Recommendation, si las tienes en RecommendationQueryDto
                InvestmentRecommendation = r.InvestmentRecommendation != null
                    ? new InvestmentRecommendationQueryDto
                    {
                        Id = r.InvestmentRecommendation.Id,
                        CommissionPercentage = r.InvestmentRecommendation.CommissionPercentage,
                        InstrumentDto = instrumentos.FirstOrDefault(i => i.Id == r.InvestmentRecommendation.InstrumentId)
                    }
                    : null
            }).ToList();

            // Devolver los DTOs mapeados
            return recommendationQueryDtos;

        }
    }
}
