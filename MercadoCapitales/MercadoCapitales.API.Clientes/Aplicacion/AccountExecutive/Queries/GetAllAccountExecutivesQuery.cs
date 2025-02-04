using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System.Collections.Generic;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Queries
{
    public class GetAllAccountExecutivesQuery : IRequest<List<AccountExecutiveDto>>
    {
        public GetAllAccountExecutivesQuery(){}
    }
}
