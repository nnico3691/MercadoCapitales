using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System.Collections.Generic;
using Model = MercadoCapitales.API.Clientes.Models;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Queries
{
    public class GetAllUsersQuery : IRequest<List<PrimaryUserDto>>
    {
    }
}
