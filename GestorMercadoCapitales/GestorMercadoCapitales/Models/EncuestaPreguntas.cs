using System;
using System.Collections.Generic;

namespace GestorMercadoCapitales.Models
{
    public class EncuestaPreguntas
    {
        public Guid? encuestaPreguntaID { get; set; }
        public string titulo { get; set; }
        public string pregunta { get; set; }

        public List<EncuestaRespuestas> encuestaRespuestas { get; set; }

    }
}
