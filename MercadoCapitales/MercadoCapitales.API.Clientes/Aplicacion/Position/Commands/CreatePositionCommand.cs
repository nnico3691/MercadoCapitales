using MediatR;
using MercadoCapitales.API.Clientes.Models.Dto; // Asegúrate de que la ruta sea correcta
using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Commands
{
    public class CreatePositionCommand : IRequest<Guid>
    {
        public PositionDto Position { get; set; } // Propiedad para recibir el DTO de posición

        // Constructor sin parámetros para permitir la deserialización
        public CreatePositionCommand() { }

        // Constructor opcional para facilitar la creación del comando
        public CreatePositionCommand(PositionDto position)
        {
            Position = position;
        }
    }
    public class CreatePositionRequest
    {
        public PositionDto Position { get; set; }
    }

}
