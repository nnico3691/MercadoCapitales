using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Clientes.Models
{
    public class ClienteEncuestas
    {
        [Key]
        public Guid? ClienteEncuestasId { get; set; }
        public Guid? EncuestaRespuesta { get; set; }
        public string ClieKey { get; set; }
    }
}
