using System.Collections.Generic;

namespace MercadoCapitales.API.Clientes.Aplicacion.Requests
{
    public class CrearEncuestaPreguntaRequest
    {
        public string Titulo { get; set; }
        public string Pregunta { get; set; }

        public List<EncuestaRespuestaRequest> ListaRespuesta { get; set; }
    }
}
