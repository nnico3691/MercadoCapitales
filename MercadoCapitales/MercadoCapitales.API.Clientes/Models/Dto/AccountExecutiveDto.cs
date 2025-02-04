using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercadoCapitales.API.Clientes.Models.Dto
{
    public class AccountExecutiveDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } // Nombre del operador
        public string Email { get; set; } // Correo electrónico (opcional)
        public string PhoneNumber { get; set; } // Número de teléfono (opcional)

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrganizationType Organization { get; set; }
    }
}
