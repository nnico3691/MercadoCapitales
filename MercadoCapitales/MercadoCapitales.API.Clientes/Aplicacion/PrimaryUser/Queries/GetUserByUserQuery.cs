using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Queries
{
    public class GetUserByUserQuery : IRequest<PrimaryUserDto>
    {
        public string UserName { get; set; }
    }
}
