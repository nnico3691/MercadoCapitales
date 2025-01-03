using MediatR;
using MercadoCapitales.API.Clientes.Persistencia;
using System.Threading.Tasks;
using System.Threading;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Commands
{
    public class DeletePrimaryUserCommandHandler : IRequestHandler<DeletePrimaryUserCommand, bool>
    {
        private readonly ContextCliente _context;

        public DeletePrimaryUserCommandHandler(ContextCliente context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePrimaryUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _context.PrimaryUser.FindAsync(request.UserId);
            if (usuario == null) return false;

            _context.PrimaryUser.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
