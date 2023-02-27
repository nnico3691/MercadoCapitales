using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Especies.Modelo
{
    public class InstrumentOrderType
    {
        [Key]
        public Guid? InstrumentOrderTypeId { get; set; }
        public string Codigo { get; set; }
        public Guid? InstrumentoId { get; set; }
    }
}
