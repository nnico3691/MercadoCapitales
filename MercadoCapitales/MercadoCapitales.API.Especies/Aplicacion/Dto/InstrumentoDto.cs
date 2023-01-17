using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Especies.Aplicacion.Dto
{
    public class InstrumentoDto
    {
        [Key]
        public Guid? InstrumentoId { get; set; }
        public string Market { get; set; }
        public string Symbol { get; set; }
    }
}
