using MediatR;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Commands
{
    public class DeleteRecommendationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteRecommendationCommand(Guid id)
        {
            Id = id;
        }
    }
}
