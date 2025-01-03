using MediatR;
using MercadoCapitales.API.Clientes.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Threading;
using Model = MercadoCapitales.API.Clientes.Modelo;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Commands
{
    public class CreatePrimaryUserCommandHandler: IRequestHandler<CreatePrimaryUserCommand, Guid>
    {

        private readonly ContextCliente _context;

        public CreatePrimaryUserCommandHandler(ContextCliente context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreatePrimaryUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Model.PrimaryUser
            {
                Username = request.Username,
                Password = request.Password,
                Account = request.Account,
                ClienteId = request.ClienteId,
            };

            await _context.PrimaryUser.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario.Id;
        }

    }
}
