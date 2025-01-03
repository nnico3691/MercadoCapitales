using System;

namespace MercadoCapitales.API.Ordenes.Models
{
    public class InstrumentId
    {
        public Guid Id { get; set; }
        public string Market { get; set; }
        public string Symbol { get; set; }
        public Guid OrdenId { get; set; } // Este será el Id de la orden a la que pertenece
        public virtual Orden Orden { get; set; }
    }
}
