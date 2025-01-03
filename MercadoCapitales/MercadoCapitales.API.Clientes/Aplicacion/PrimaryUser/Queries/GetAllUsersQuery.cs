using MediatR;
using MercadoCapitales.API.Clientes.Modelo.Dto;
using System.Collections.Generic;
using Model = MercadoCapitales.API.Clientes.Modelo;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Queries
{
    public class GetAllUsersQuery : IRequest<List<PrimaryUserDto>>
    {
    }
}
