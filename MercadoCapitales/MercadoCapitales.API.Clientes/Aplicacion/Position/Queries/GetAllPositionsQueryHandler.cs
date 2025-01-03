using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Clientes.Modelo.Dto;
using MercadoCapitales.API.Clientes.Persistencia;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;
using System;
using Primary;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Queries
{
    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, List<PositionDto>>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;

        public GetAllPositionsQueryHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PositionDto>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {

            var api = new Api(Api.DemoEndpoint);
            await api.Login(request.PrimaryUser.UserName, request.PrimaryUser.Password);

            // Call the GetPositions method to retrieve positions for the account
            var positions = await api.GetPositions(request.PrimaryUser.Account);
            var accountReport = await api.GetAccountReport(request.PrimaryUser.Account);
            var detailedPosition = await api.GetDetailedPosition(request.PrimaryUser.Account);

            // Validate response
            if (positions == null || !positions.Any())
            {
              throw new Exception("No positions found for the specified account.");
            }

            // Obtener todas las posiciones desde la base de datos filtradas por nombre de usuario
            var positionsCliente = await _context.Position
                .Include(p => p.PrimaryUser) // Incluir la relación con PrimaryUser
                .Where(p => p.PrimaryUser.Username == request.PrimaryUser.UserName) // Filtrar por nombre de usuario
                .ToListAsync(cancellationToken); // Cambiar a ToListAsync para obtener una lista

            // Convertir las posiciones a PositionDto usando AutoMapper
            var positionDtos = _mapper.Map<List<PositionDto>>(positionsCliente);

            return positionDtos; // Devolver la lista de PositionDto
        }

    }
}
