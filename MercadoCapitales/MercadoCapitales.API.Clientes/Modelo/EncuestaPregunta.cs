using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MercadoCapitales.API.Clientes.Modelo
{
    public class EncuestaPregunta
    {
        [Key]
        public Guid? EncuestaPreguntaId { get; set; }
        public string Titulo { get; set; }
        public string Pregunta { get; set; }

        public List<EncuestaRespuesta> encuestaRespuestas { get; set; }
    }
}
