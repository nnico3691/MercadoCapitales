using MediatR;
using MercadoCapitales.API.Ordenes.Models;
using MercadoCapitales.API.Ordenes.Models.Dto;
using System.Collections.Generic;

namespace MercadoCapitales.API.Ordenes.Aplicacion.Order.Queries
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
        public string User { get; set; }

        public GetOrdersQuery(string user)
        {
            User = user;
        }
    }

}
