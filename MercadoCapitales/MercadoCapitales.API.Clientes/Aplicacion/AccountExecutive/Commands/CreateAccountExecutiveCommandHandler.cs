using AutoMapper;
using MediatR;
using MercadoCapitales.API.Clientes.Persistencia;
using Model = MercadoCapitales.API.Clientes.Models;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands
{
    public class CreateAccountExecutiveCommandHandler : IRequestHandler<CreateAccountExecutiveCommand, Guid>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;

        public CreateAccountExecutiveCommandHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateAccountExecutiveCommand request, CancellationToken cancellationToken)
        {
            var accountExecutive = _mapper.Map<Model.AccountExecutive>(request);

            accountExecutive.CreatedAt = DateTime.Now;
            accountExecutive.CreatedBy = "AUT";
            accountExecutive.Active = true;

            await _context.AccountExecutive.AddAsync(accountExecutive, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return accountExecutive.Id;
        }
    }
}
