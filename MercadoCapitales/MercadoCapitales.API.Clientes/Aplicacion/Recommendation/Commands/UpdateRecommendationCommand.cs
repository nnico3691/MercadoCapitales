using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Commands
{
    public class UpdateRecommendationCommand : IRequest<bool>
    {
        public RecommendationCommandDto Recommendation { get; set; }
        public Guid Id { get; set; }
        public UpdateRecommendationCommand() { }

        public UpdateRecommendationCommand(Guid id, RecommendationCommandDto recommendation)
        {
            Id = id;
            Recommendation = recommendation;
        }
    }
}
