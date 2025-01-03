using MediatR;
using MercadoCapitales.API.Ordenes.Models.Dto;
using MercadoCapitales.API.Ordenes.Persistencia;
using MercadoCapitales.API.Ordenes.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Ordenes.Aplicacion.Order.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly ContextOrden _context;
        private readonly IClienteService _clienteService;
        public GetOrderByIdQueryHandler(ContextOrden context, IClienteService clienteService)
        {
            _context = context;
            _clienteService = clienteService;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            // Buscar la orden en la base de datos usando el ID proporcionado en la solicitud
            var orden = await _context.Orden
                .Include(o => o.StatusHistory) // Incluye el historial de estados de la orden
                .Include(o => o.InstrumentId) // Incluye el instrumento asociado a la orden
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            // Verifica si se encontró la orden
            if (orden == null)
            {
                throw new KeyNotFoundException($"Order with ID {request.Id} not found.");
            }

            // Mapeo del Instrumento
            var Instrument = new InstrumentDto
            {
                Id = orden.InstrumentId.Id,
                Market = orden.InstrumentId.Market,
                Symbol = orden.InstrumentId.Symbol
            };

            var orderDto = new OrderDto
            {
                Id = orden.Id,
                Proprietary = orden.Proprietary,
                ClientOrderId = orden.ClientOrderId,
                CancelPrevious = orden.CancelPrevious,
                Iceberg = orden.Iceberg,
                DisplayQuantity = orden.DisplayQuantity,
                InstrumentId = Instrument,
                Price = orden.Price,
                Quantity = orden.Quantity,
                Type = orden.Type,
                Side = orden.Side,
                Expiration = orden.Expiration,
                ExpirationDate = orden.ExpirationDate,
                StatusHistory = orden.StatusHistory.Select(s => new OrderStatusDto
                {
                    Id = s.Id,
                    Account = s.Account,
                    ExecutionId = s.ExecutionId,
                    TransactionTime = s.TransactionTime,
                    AveragePrice = s.AveragePrice,
                    LastPrice = s.LastPrice,
                    LastQuantity = s.LastQuantity,
                    CumulativeQuantity = s.CumulativeQuantity,
                    LeavesQuantity = s.LeavesQuantity,
                    Status = s.Status,
                    StatusText = s.StatusText
                }).ToList()
            };

            return orderDto;
        }
    }
}
