using MediatR;
using MercadoCapitales.API.Clientes.Modelo.Dto;
using System;
using System.Collections.Generic;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Queries
{
    public class GetAllPositionsQuery : IRequest<List<PositionDto>>
    {
        public PrimaryUserDto PrimaryUser { get; set; }

        public GetAllPositionsQuery(PrimaryUserDto primaryUser)
        {
            PrimaryUser = primaryUser;
        }
    }
}
