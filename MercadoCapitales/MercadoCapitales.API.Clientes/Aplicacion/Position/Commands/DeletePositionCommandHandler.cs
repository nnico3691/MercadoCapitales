using MediatR;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Clientes.Persistencia;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Commands
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, bool>
    {
        private readonly ContextCliente _context;

        public DeletePositionCommandHandler(ContextCliente context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _context.Position.FindAsync(request.Id);

            if (position == null) return false;

            _context.Position.Remove(position);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
