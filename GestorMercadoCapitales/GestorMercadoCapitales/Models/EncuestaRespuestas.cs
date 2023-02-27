using System;

namespace GestorMercadoCapitales.Models
{
    public class EncuestaRespuestas
    {
        public Guid? encuestaRespuestaId { get; set; }
        public string Respuesta { get; set; }
        public int Puntos { get; set; }
        public string NameInput { get; set; }
        public string TipoInput { get; set; }
        public Guid? EncuestaPreguntaId { get; set; }

    }
}
