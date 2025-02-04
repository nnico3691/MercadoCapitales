using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Queries;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Queries
{
    public class GetRecommendationByIdQuery : IRequest<RecommendationQueryDto>
    {
        public Guid Id { get; set; }
        public GetRecommendationByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}


