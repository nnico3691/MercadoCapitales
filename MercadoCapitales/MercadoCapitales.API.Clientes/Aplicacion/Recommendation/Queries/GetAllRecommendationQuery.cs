using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;
using System.Collections.Generic;

namespace MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Queries
{
    public class GetAllRecommendationQuery : IRequest<List<RecommendationQueryDto>>
    {
        
    }
}
