using AutoMapper;
using MediatR;
using MercadoCapitales.API.Clientes.Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands
{
    public class UpdateAccountExecutiveCommandHandler : IRequestHandler<UpdateAccountExecutiveCommand, bool>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;

        public UpdateAccountExecutiveCommandHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAccountExecutiveCommand request, CancellationToken cancellationToken)
        {
            var accountExecutive = await _context.AccountExecutive
                .FirstOrDefaultAsync(ae => ae.Id == request.Id, cancellationToken);

            if (accountExecutive == null)
                return false; // Manejar en el controlador con un 404

            // Mapea las propiedades del request a la entidad existente
            _mapper.Map(request.AccountExecutiveDto, accountExecutive);

            _context.AccountExecutive.Update(accountExecutive);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
