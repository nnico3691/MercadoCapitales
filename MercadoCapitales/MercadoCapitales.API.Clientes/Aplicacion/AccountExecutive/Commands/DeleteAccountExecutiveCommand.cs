using MediatR;
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands
{
    public class DeleteAccountExecutiveCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteAccountExecutiveCommand(Guid guid) 
        {
            Id = guid;
        }
    }
}
