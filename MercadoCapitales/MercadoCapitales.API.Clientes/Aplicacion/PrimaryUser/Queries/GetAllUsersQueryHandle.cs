using MediatR;
using MercadoCapitales.API.Clientes.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using MercadoCapitales.API.Clientes.Modelo.Dto;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Queries
{
    public class GetAllUsersQueryHandle : IRequestHandler<GetAllUsersQuery, List<PrimaryUserDto>>
    {
        private readonly ContextCliente _context;
        public GetAllUsersQueryHandle(ContextCliente contextCliente)
        {
            _context = contextCliente;
        }

        public async Task<List<PrimaryUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // Obtener todos los usuarios desde la base de datos
            var users = await _context.PrimaryUser.ToListAsync(cancellationToken);

            // Mapear a DTOs
            var userDtos = users.Select(user => new PrimaryUserDto
            {
                Id = user.Id,
                UserName = user.Username,
                Account = user.Account
            }).ToList();

            return userDtos;
        }
    }

}

