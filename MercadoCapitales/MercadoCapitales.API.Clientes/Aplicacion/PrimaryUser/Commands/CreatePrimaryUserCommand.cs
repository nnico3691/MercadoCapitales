using MediatR;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Commands
{
    public class CreatePrimaryUserCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }
        public Guid? ClienteId { get; set; }
    }
}
