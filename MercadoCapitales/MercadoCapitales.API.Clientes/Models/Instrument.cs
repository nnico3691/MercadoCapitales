using System;

namespace MercadoCapitales.API.Clientes.Models
{
    public class Instrument
    {
        public Guid Id { get; set; }
        public string SymbolReference { get; set; }
        public int SettType { get; set; }
        public Guid PositionId { get; set; } // Este será el Id de la orden a la que pertenece
        public virtual Position Position { get; set; }
    }
}
