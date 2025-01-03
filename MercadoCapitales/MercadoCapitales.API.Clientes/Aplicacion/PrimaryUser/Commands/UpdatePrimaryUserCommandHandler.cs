using MediatR;
using MercadoCapitales.API.Clientes.Persistencia;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Commands
{
    public class UpdatePrimaryUserCommandHandler : IRequestHandler<UpdatePrimaryUserCommand, bool>
    {
        private readonly ContextCliente _context;

        public UpdatePrimaryUserCommandHandler(ContextCliente context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdatePrimaryUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _context.PrimaryUser.FindAsync(request.Id);
            if (usuario == null) return false;

            usuario.Username = request.Username;
            usuario.Password = request.Password;
            usuario.Account = request.Account;

            _context.PrimaryUser.Update(usuario);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
