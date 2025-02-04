using MediatR;
using MercadoCapitales.API.Clientes.Persistencia;
using Model = MercadoCapitales.API.Clientes.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MercadoCapitales.API.Clientes.Models;

namespace MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Commands
{
    public class CreateRecommendationCommandHandler : IRequestHandler<CreateRecommendationCommand, Guid>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;


        public CreateRecommendationCommandHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateRecommendationCommand request, CancellationToken cancellationToken)
        {
            // Validar el DTO antes de hacer el mapeo
            if (request.RecommendationDto == null)
            {
                throw new ArgumentException("La recomendación es nula.");
            }

            // Mapeo del DTO a la entidad
            var recommendation = _mapper.Map<Model.Recommendation>(request);

            // Asignación de campos adicionales
            recommendation.CreatedAt = DateTime.UtcNow; // Mejor usar UTC para consistencia
            recommendation.CreatedBy = "AUT"; // Aquí puedes obtener el usuario actual si es necesario
            recommendation.Active = true;

            // Agregar a la base de datos
            _context.Recommendation.Add(recommendation);

            // Manejo de la recomendación de inversión si está presente
            if (request.RecommendationDto.InvestmentRecommendation != null)
            {
                var investmentRecommendation = _mapper.Map<Model.InvestmentRecommendation>(request.RecommendationDto.InvestmentRecommendation);
                investmentRecommendation.Recommendation = recommendation;
                recommendation.InvestmentRecommendation = investmentRecommendation;
            }

            // Guardar los cambios de forma asincrónica
            await _context.SaveChangesAsync(cancellationToken);

            // Retornar el ID de la recomendación creada
            return recommendation.Id;
        }
    }
}
