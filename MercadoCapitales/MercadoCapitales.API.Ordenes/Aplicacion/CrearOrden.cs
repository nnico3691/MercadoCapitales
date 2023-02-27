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

                    // Get a valid instrument and price
                    var instruments = await api.GetAllInstruments();
                    var instrumentId = instruments.Last(i => i.Symbol == request.Symbol);

                    var today = DateTime.Today;
                    var prices = await api.GetHistoricalTrades(instrumentId, today.AddDays(-3), today);

                    var order = new Order
                    {
                        InstrumentId = instrumentId,
                        Expiration = Expiration.Day,
                        Type = Primary.Data.Orders.Type.Limit,
                        Price = request.Price,
                        Side = (request.Side == "Buy" ? Side.Buy : Side.Sell),
                        Quantity = request.Quantity
                    };

                    var orderId = await api.SubmitOrder(Api.DemoAccount, order);

                    var retrievedOrder = await api.GetOrderStatus(orderId);

                    if (retrievedOrder.Status == "OK")
                        return Unit.Value;
                    else
                        throw new Exception("Error: " + retrievedOrder.Status);
                }
                catch(Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }

                throw new Exception("Errores en la inserción de la Orden");

            }
        }

    }
}
