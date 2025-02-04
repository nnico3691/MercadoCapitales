using AutoMapper;
using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion.Position.Queries;
using MercadoCapitales.API.Clientes.Models.Dto;
using MercadoCapitales.API.Clientes.Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Queries
{
    public class GetAccountExecutiveByIdQueryHandler : IRequestHandler<GetAccountExecutiveByIdQuery, AccountExecutiveDto>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;

        public GetAccountExecutiveByIdQueryHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountExecutiveDto> Handle(GetAccountExecutiveByIdQuery request, CancellationToken cancellationToken)
        {
            var accountExecutive = await _context.AccountExecutive
                .AsNoTracking()
                .FirstOrDefaultAsync(ae => ae.Id == request.Id, cancellationToken);

            if (accountExecutive == null)
                return null; // Manejar esto en el controlador con un 404

            return _mapper.Map<AccountExecutiveDto>(accountExecutive);
        }

    }
}
