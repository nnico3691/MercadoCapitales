using MediatR;
using System;

namespace MercadoCapitales.API.Ordenes.Aplicacion.Order.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string Symbol { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public string Side { get; set; }

    }

}
