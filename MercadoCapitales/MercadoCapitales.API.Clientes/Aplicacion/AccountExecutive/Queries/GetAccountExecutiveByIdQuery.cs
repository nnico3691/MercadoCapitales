using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Queries
{
    public class GetAccountExecutiveByIdQuery : IRequest<AccountExecutiveDto>
    {
        public Guid Id { get; set; }
        public GetAccountExecutiveByIdQuery(Guid id) 
        {
            Id = id;
        }
    }
}
