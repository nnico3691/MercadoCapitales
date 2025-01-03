using MediatR;

namespace MercadoCapitales.API.Ordenes.Aplicacion.Order.Commands
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Side { get; set; }
    }
}
