using MediatR;
using MercadoCapitales.API.Ordenes.Models.Dto;
using System;

namespace MercadoCapitales.API.Ordenes.Aplicacion.Order.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public GetOrderByIdQuery(Guid id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}
