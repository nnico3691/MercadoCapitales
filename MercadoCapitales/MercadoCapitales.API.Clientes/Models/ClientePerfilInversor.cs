using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MercadoCapitales.API.Clientes.Models
{
    public class ClientePerfilInversor
    {
        [Key]
        public Guid? ClientePerfilInversorId { get; set; }
        public Guid? EncuestaRespuestaId { get; set; }
        public Guid? ClienteId { get; set; }
    }
}
