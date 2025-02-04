using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Commands
{
    public class CreateRecommendationCommand : IRequest<Guid>
    {
        public RecommendationCommandDto RecommendationDto { get; set; }
        public CreateRecommendationCommand() { }
        public CreateRecommendationCommand(RecommendationCommandDto recommendationDto)
        {
            RecommendationDto = recommendationDto;
        }
    }
}
