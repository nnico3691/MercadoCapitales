using MediatR;
using MercadoCapitales.API.Clientes.Models;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands
{
    public class UpdateAccountExecutiveCommand : IRequest<bool>
    {
        public AccountExecutiveDto AccountExecutiveDto;
        public Guid Id { get; set; }
        public UpdateAccountExecutiveCommand(Guid id,AccountExecutiveDto accountExecutiveDto)
        {
            Id = id;
            AccountExecutiveDto = accountExecutiveDto;
        }
    }
}
