using MediatR;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Clientes.Modelo.Dto;
using MercadoCapitales.API.Clientes.Persistencia;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Queries
{
    public class GetPositionByIdQueryHandler : IRequestHandler<GetPositionByUserQuery, PositionDto>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;

        public GetPositionByIdQueryHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PositionDto> Handle(GetPositionByUserQuery request, CancellationToken cancellationToken)
        {
            // Buscar la posición por ID y filtrar por el nombre de usuario del PrimaryUser
            var position = await _context.Position
                .Include(p => p.PrimaryUser) // Incluir la relación con PrimaryUser
                .FirstOrDefaultAsync(p => p.Id == request.Id && p.PrimaryUser.Username == request.UserName, cancellationToken);

            // Verificar si la posición fue encontrada
            if (position == null)
            {
                return null; // O lanzar una excepción si prefieres
            }

            // Convertir la entidad Position a PositionDto usando AutoMapper
            var positionDto = _mapper.Map<PositionDto>(position);

            return positionDto; // Devolver el DTO
        }

    }
}
