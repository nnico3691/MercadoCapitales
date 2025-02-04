using MediatR;
using System.Threading.Tasks;
using System.Threading;
using model = MercadoCapitales.API.Clientes.Models;
using MercadoCapitales.API.Clientes.Persistencia;
using AutoMapper; // Asegúrate de incluir esta línea
using System;
using Primary;
using System.Linq;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Commands
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Guid>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper; 

        public CreatePositionCommandHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; // Inicializar el mapper
        }

        public async Task<Guid> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            // Map PositionDto to Position using AutoMapper
            var position = _mapper.Map<model.Position>(request.Position);

            // Assign additional properties if necessary
            position.PrimaryUserId = request.Position.PrimaryUserId; // Assign the primary user ID

            // Add the new position to the context only if we have valid positions
            _context.Position.Add(position);
            await _context.SaveChangesAsync(cancellationToken);

            return position.Id;
        }

    }
}
