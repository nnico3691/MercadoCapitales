using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MercadoCapitales.API.Clientes.Persistencia;
using MercadoCapitales.API.Clientes.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Queries
{
    public class GetAllAccountExecutivesHandler : IRequestHandler<GetAllAccountExecutivesQuery,List<AccountExecutiveDto>>
    {
        private readonly ContextCliente _context;
        private readonly IMapper _mapper;
        public GetAllAccountExecutivesHandler(ContextCliente context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AccountExecutiveDto>> Handle(GetAllAccountExecutivesQuery request, CancellationToken cancellationToken)
        {
            return await _context.AccountExecutive
                .Select(ae => new AccountExecutiveDto
                {
                    Id = ae.Id,
                    Name = ae.Name,
                    Email = ae.Email,
                    PhoneNumber = ae.PhoneNumber,
                    Organization = ae.Organization
                })
                .ToListAsync(cancellationToken);
        }

    }
}
