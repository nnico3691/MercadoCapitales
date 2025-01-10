using MediatR;
using MercadoCapitales.API.Ordenes.Persistencia;
using System;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MercadoCapitales.API.Ordenes.Models;
using Primary;
using System.Linq;
using MercadoCapitales.API.Ordenes.Services;
using MercadoCapitales.API.Ordenes.Mappings.Order;

namespace MercadoCapitales.API.Ordenes.Aplicacion.Order.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {

        private readonly ContextOrden _context;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(ContextOrden context, IClienteService clienteService, IMapper mapper)
        {
            _context = context;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var api = new Api(Api.DemoEndpoint);
                var PrimaryUserDto = await _clienteService.GetPrimaryUserAsync(request.UserName);
                await api.Login(PrimaryUserDto.Username, PrimaryUserDto.Password);

                // Obtener un instrumento válido y su precio
                var instruments = await api.GetAllInstruments();
                var instrumentId = instruments.LastOrDefault(i => i.Symbol == request.Symbol);
                if (instrumentId == null)
                {
                    // Manejar el caso donde no se encontró ningún instrumento
                    throw new InvalidOperationException($"No instrument found with symbol {request.Symbol}.");
                }


                var today = DateTime.Today;
                var prices = await api.GetHistoricalTrades(instrumentId, today.AddDays(-3), today);

                var order = new Primary.Data.Orders.Order
                {
                    InstrumentId = instrumentId,
                    Expiration = Primary.Data.Orders.Expiration.Day,
                    Type = Primary.Data.Orders.Type.Limit,
                    Price = request.Price,
                    Side = (request.Side == "Buy" ? Primary.Data.Orders.Side.Buy : Primary.Data.Orders.Side.Sell),
                    Quantity = request.Quantity
                };

                var orderId = await api.SubmitOrder(PrimaryUserDto.Account, order);
                var retrievedOrder = await api.GetOrderStatus(orderId);
                var orderStatusData = retrievedOrder.Order;

                // Usar el mapeador para crear una nueva instancia de OrderStatus
                var orderStatus = _mapper.Map<Models.OrderStatus>(orderStatusData);
                // Mapear la orden a la entidad Orden
                var orden = _mapper.Map<Orden>(order);

                orden.ClientOrderId = orderId.ClientOrderId;
                orden.Proprietary = orderId.Proprietary;

                orderStatus.Account = orderStatusData.Account.Id; // Asignar solo el Id

                // Agregar el estado a la historia de estados
                orden.StatusHistory.Add(orderStatus);

                // Establecer el OrdenId en OrderStatus
                orderStatus.OrdenId = orden.Id;

                _context.Orden.Add(orden);
                await _context.SaveChangesAsync();

                if (retrievedOrder.Status == "OK")
                    return orden.Id;
                else
                    throw new Exception("Error: " + retrievedOrder.Status);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            throw new Exception("Errores en la inserción de la Orden");
        }

    }
}
