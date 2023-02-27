using MercadoCapitales.API.Clientes.Modelo;
using System;
using System.Collections.Generic;

namespace MercadoCapitales.API.Clientes.Dto
{
    public class EncuestaPreguntaDto
    {
        public Guid? EncuestaPreguntaId { get; set; }
        public string Titulo { get; set; }
        public string Pregunta { get; set; }

        public List<EncuestaRespuesta> encuestaRespuestas { get; set; }
    }
}
