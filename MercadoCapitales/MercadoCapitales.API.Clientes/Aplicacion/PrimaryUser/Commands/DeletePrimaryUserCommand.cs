using MediatR;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Commands
{
    public class DeletePrimaryUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
    }
}
