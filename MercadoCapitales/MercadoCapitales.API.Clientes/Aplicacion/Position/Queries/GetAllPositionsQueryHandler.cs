using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Clientes.Modelo.Dto;
using MercadoCapitales.API.Clientes.Persistencia;
using Model = MercadoCapitales.API.Clientes.Modelo;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;
using System;
using MercadoCapitales.API.Clientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Queries
{
    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, List<PositionDto>>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;
        private readonly IMarketConnectService _marketConnectService;

        public GetAllPositionsQueryHandler(ContextCliente context, IMapper mapper, IMarketConnectService marketConnectService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _marketConnectService = marketConnectService ?? throw new ArgumentNullException(nameof(marketConnectService));
        }

        public async Task<List<PositionDto>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            // Usar el servicio de autenticación para iniciar sesión
            bool loginSuccessful = await _marketConnectService.LoginAsync(request.PrimaryUser.UserName, request.PrimaryUser.Password);

            if (!loginSuccessful)
            {
                throw new UnauthorizedAccessException("Login failed for the specified user.");
            }

            // Obtener el usuario primario por nombre de usuario
            var primaryUser = await _context.PrimaryUser
                .FirstOrDefaultAsync(u => u.Username == request.PrimaryUser.UserName, cancellationToken);

            if (primaryUser == null)
            {
                throw new KeyNotFoundException("El usuario primario no existe en la base de datos.");
            }

            // Llamar al método GetPositions para recuperar posiciones para la cuenta
            var positionsResult = await _marketConnectService.GetPositionsAsync(request.PrimaryUser.Account);

            if (positionsResult is NotFoundObjectResult notFoundResult)
            {
                throw new Exception(notFoundResult.Value.ToString());
            }
            else if (positionsResult is OkObjectResult okResult)
            {
                var positions = okResult.Value as List<Model.Position>;

                // Validar respuesta
                if (positions == null || !positions.Any())
                {
                    throw new Exception("No positions found for the specified account.");
                }

                // Obtener todas las posiciones existentes desde la base de datos filtradas por el ID del usuario primario
                var existingPositions = await _context.Position
                    .Where(p => p.PrimaryUserId == primaryUser.Id) // Filtrar por ID del usuario primario
                    .ToListAsync(cancellationToken);

                // Crear un diccionario para facilitar la búsqueda de posiciones existentes por TradingSymbol
                var existingPositionsDict = existingPositions.ToDictionary(ep => ep.TradingSymbol);

                // Lista para nuevas posiciones
                var newPositions = new List<Model.Position>();

                foreach (var position in positions)
                {
                    if (existingPositionsDict.TryGetValue(position.TradingSymbol, out var existingPosition))
                    {
                        // Actualizar la posición existente
                        UpdateExistingPosition(existingPosition, position);
                    }
                    else
                    {
                        // Si no existe, agregar a la lista de nuevas posiciones
                        var newPosition = _mapper.Map<Model.Position>(position); // Mapeo desde API a tu modelo
                        newPosition.PrimaryUserId = primaryUser.Id; // Asignar el ID del usuario primario
                        newPositions.Add(newPosition); // Agregar a la lista de nuevas posiciones
                    }
                }

                // Insertar todas las nuevas posiciones de una sola vez
                if (newPositions.Any())
                {
                    await _context.Position.AddRangeAsync(newPositions, cancellationToken);
                }

                // Guardar cambios en la base de datos
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<List<PositionDto>>(existingPositions); // Devolver la lista de PositionDto existentes (actualizadas)
            }
            else
            {
                throw new Exception("An unexpected error occurred while retrieving positions.");
            }
        }

        private void UpdateExistingPosition(Model.Position existingPosition, Model.Position updatedPosition)
        {
            existingPosition.BuySize = updatedPosition.BuySize;
            existingPosition.BuyPrice = updatedPosition.BuyPrice;
            existingPosition.SellSize = updatedPosition.SellSize;
            existingPosition.SellPrice = updatedPosition.SellPrice;
            existingPosition.TotalDailyDiff = updatedPosition.TotalDailyDiff;
            existingPosition.TotalDiff = updatedPosition.TotalDiff;
        }
    }
}
