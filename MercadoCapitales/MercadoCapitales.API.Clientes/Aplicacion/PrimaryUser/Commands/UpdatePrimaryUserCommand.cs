using MediatR;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Commands
{
    public class UpdatePrimaryUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }
    }
}
