using MediatR;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Commands
{
    public class DeletePositionCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeletePositionCommand(Guid id)
        {
            Id = id;
        }
    }

}
