using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Especies.Modelo
{
    public class TipoPanelPrecio
    {
        [Key]
        public Guid? TipoPanelPrecioId { get; set; }
        public string cficode { get; set; }
        public string marketSegmentId { get; set; }
        public string Tipo { get; set; }
        public string Mercado { get; set; }
    }
}
