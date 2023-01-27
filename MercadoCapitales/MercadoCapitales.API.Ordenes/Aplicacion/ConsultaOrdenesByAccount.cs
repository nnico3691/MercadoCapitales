using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using static Primary.Api;
using MercadoCapitales.API.Ordenes.Persistencia;
using Primary;
using Primary.Data;

namespace MercadoCapitales.API.Ordenes.Aplicacion
{
    public class ConsultaOrdenesByAccount
    {
        public class ListaOrdenes : IRequest<GetOrderResponse> { }

        public class Manejador : IRequestHandler<ListaOrdenes, GetOrderResponse>
        {
            private readonly ContextOrden _contexto;

            public Manejador(ContextOrden contexto)
            {
                _contexto = contexto;
            }
            public async Task<GetOrderResponse> Handle(ListaOrdenes request, CancellationToken cancellationToken)
            {
                var api = new Api(Api.DemoEndpoint);
                await api.Login(Api.DemoUsername, Api.DemoPassword);

                Account account = new Account
                {
                    accountId = Api.DemoAccount
                };

                var ordenes = await api.GetOrderFilleds(account);

                return ordenes;
            }
        }
    }
}
