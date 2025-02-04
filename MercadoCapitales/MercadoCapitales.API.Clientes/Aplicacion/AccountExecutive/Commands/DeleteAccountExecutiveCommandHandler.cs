using MediatR;
using MercadoCapitales.API.Clientes.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands
{
    public class DeleteAccountExecutiveCommandHandler : IRequestHandler<DeleteAccountExecutiveCommand, bool>
    {
        private readonly ContextCliente _context;

        public DeleteAccountExecutiveCommandHandler(ContextCliente context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteAccountExecutiveCommand request, CancellationToken cancellationToken)
        {
            var accountExecutive = await _context.AccountExecutive
                .FirstOrDefaultAsync(ae => ae.Id == request.Id, cancellationToken);

            if (accountExecutive == null)
                return false; // Manejar en el controlador con un 404

            accountExecutive.Active = false; // Desactivar en lugar de eliminar
            _context.AccountExecutive.Update(accountExecutive);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
