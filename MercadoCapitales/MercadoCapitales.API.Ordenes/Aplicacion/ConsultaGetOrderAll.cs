using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using static Primary.Api;
using MercadoCapitales.API.Ordenes.Persistencia;
using Primary;
using Primary.Data;
using Primary.Data.Orders;

namespace MercadoCapitales.API.Ordenes.Aplicacion
{
    public class ConsultaGetOrderAll
    {
        public class ListaOrdenes : IRequest<List<OrderStatus>> { }

        public class Manejador : IRequestHandler<ListaOrdenes, List<OrderStatus>>
        {
            private readonly ContextOrden _contexto;

            public Manejador(ContextOrden contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<OrderStatus>> Handle(ListaOrdenes request, CancellationToken cancellationToken)
            {
                var api = new Api(Api.DemoEndpoint);
                await api.Login(Api.DemoUsername, Api.DemoPassword);

                Account account = new Account
                {
                    accountId = Api.DemoAccount
                };

                var result = await api.GetOrderAll(account);

                return result.Orders;
            }
        }
    }
}
