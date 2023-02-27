using System;
using System.Collections.Generic;

namespace GestorMercadoCapitales.Models
{
    public class EncuestaPreguntas
    {

        public EncuestaPreguntas() { 
            MensajeRetorno = new MensajeRetorno();
        }

        public Guid? encuestaPreguntaID { get; set; }
        public string titulo { get; set; }
        public string pregunta { get; set; }

        public List<EncuestaRespuestas> encuestaRespuestas { get; set; }
        public MensajeRetorno MensajeRetorno { get; set; }

    }
}
