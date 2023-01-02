using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorMercadoCapitales.Models
{
    public class CotizacionAccion
    {
        
        //public Guid? PrecioId { get; set; }
        public string ticker { get; set; }
        public float? precio { get; set; }
        public float? varPorcentual { get; set; }
        public float? precioA { get; set; }
        public float? cCompra { get; set; }
        public float? pCompra { get; set; }
        public float? pVenta { get; set; }
        public float? cVenta { get; set; }
        public float? min { get; set; }
        public float? max { get; set; }
        public string ajuste { get; set; }
        public string volNom { get; set; }
        public float? monto { get; set; }
        public int? oper { get; set; }
        public string hora { get; set; }
    }
    
}
