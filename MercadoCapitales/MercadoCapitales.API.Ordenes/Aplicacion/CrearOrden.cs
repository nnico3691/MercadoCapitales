using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using MercadoCapitales.API.Ordenes.Persistencia;
using MercadoCapitales.API.Ordenes.Modelo;
using System.Numerics;
using Primary;
using System.Linq;
using Primary.Data.Orders;
using Primary.Data;
using AutoMapper;

namespace MercadoCapitales.API.Ordenes.Aplicacion
{
    public class CrearOrden
    {
        public class Ejecuta : IRequest
        {
            public string Symbol { get; set; }
            public decimal? Price { get; set; }
            public int Quantity { get; set; }
            public string Side { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextOrden _contexto;

            public Manejador(ContextOrden contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                try
                {
                    var api = new Api(Api.DemoEndpoint);
                    await api.Login(Api.DemoUsername, Api.DemoPassword);

                    // Obtener un instrumento válido y su precio
                    var instruments = await api.GetAllInstruments();
                    var instrumentId = instruments.Last(i => i.Symbol == request.Symbol);

                    var today = DateTime.Today;
                    var prices = await api.GetHistoricalTrades(instrumentId, today.AddDays(-3), today);

                    var order = new Order
                    {
                        InstrumentId = instrumentId,
                        Expiration = Primary.Data.Orders.Expiration.Day,
                        Type = Primary.Data.Orders.Type.Limit,
                        Price = request.Price,
                        Side = (request.Side == "Buy" ? Primary.Data.Orders.Side.Buy : Primary.Data.Orders.Side.Sell),
                        Quantity = request.Quantity
                    };

                    var orderId = await api.SubmitOrder(Api.DemoAccount, order);
                    var retrievedOrder = await api.GetOrderStatus(orderId);
                    var orderStatusData = retrievedOrder.Order;

                    // Configurar el mapeador
                    var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
                    var mapper = configuration.CreateMapper();

                    // Usar el mapeador para crear una nueva instancia de OrderStatus
                    var orderStatus = mapper.Map<Modelo.OrderStatus>(orderStatusData);
                    // Mapear la orden a la entidad Orden
                    var orden = mapper.Map<Orden>(order);

                    orden.ClientOrderId = orderId.ClientOrderId;
                    orden.Proprietary = orderId.Proprietary;

                    orderStatus.Account = orderStatusData.Account.Id; // Asignar solo el Id
                 
                    // Agregar el estado a la historia de estados
                    orden.StatusHistory.Add(orderStatus);

                    // Establecer el OrdenId en OrderStatus
                    orderStatus.OrdenId = orden.Id;

                    _contexto.Orden.Add(orden);
                    await _contexto.SaveChangesAsync();

                    if (retrievedOrder.Status == "OK")
                        return Unit.Value;
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

}
