using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Especies.Modelo
{
    public class InstrumentTimeInForce
    {
        [Key]
        public Guid? InstrumentTimesInForceId { get; set; }
        public string Codigo { get; set; }
        public Guid? InstrumentoId { get; set; }
    }
}
