using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Queries
{
    public class GetPositionByUserQuery : IRequest<PositionDto>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public GetPositionByUserQuery(Guid id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }

}
