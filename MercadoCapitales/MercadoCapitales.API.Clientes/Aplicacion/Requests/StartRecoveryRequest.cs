using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoCapitales.API.Clientes.Aplicacion.Requests
{
    public class StartRecoveryRequest
    {
        public Guid? ClienteId { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
