using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Especies.Models
{
    public class InstrumentOrderType
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public Guid InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }
    }
}
