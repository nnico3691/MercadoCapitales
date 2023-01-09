using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Clientes.Modelo
{
    public class EncuestaRespuesta
    {
        [Key]
        public Guid? EncuestaRespuestaId { get; set; }
        public string Respuesta { get; set; }
        public int Puntos { get; set; }
        public string NameInput { get; set; }
        public string TipoInput { get; set; }
        public Guid? EncuestaPreguntaId { get; set; }
    }
}
