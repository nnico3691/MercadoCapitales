using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands
{
    public class CreateAccountExecutiveCommand : IRequest<Guid>
    {
        public AccountExecutiveDto AccountExecutiveDto { get; set; }
        public CreateAccountExecutiveCommand() { }
        public CreateAccountExecutiveCommand(AccountExecutiveDto accountExecutiveDto)
        {
            AccountExecutiveDto = accountExecutiveDto;
        }
    }
}
