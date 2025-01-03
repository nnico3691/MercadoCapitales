using MediatR;

namespace MercadoCapitales.API.Ordenes.Aplicacion.Order.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
