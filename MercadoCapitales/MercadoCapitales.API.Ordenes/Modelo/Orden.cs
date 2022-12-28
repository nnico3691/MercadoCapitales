using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Ordenes.Modelo
{
    public class Orden
    {
        [Key]
        public Guid? PrecioId { get; set; }
        public string OrdenCodigo { get; set; } /*BYMA, FCI, LICITACIONES, ROFEX, CAUCION*/
        public string TipoCompraVenta { get; set; } /*COMPRA, VENTA*/

        /*COMITENTE - CLIENTE*/
        public string Comitente { get; set; }
        public string Cliente { get; set; }
        public int ComitenteId { get; set; }
        public int ClienteId { get; set; }
        public string Ticker { get; set; }
        public float Cantidad { get; set; }
        public string TipoDeOrden { get; set; } /*Limite, Stop con limite*/
        public float Precio { get; set; }
        public float Importe { get; set; }
        public int ValidezOferta { get;set; } /* 0- Hasta el día 1- Hasta Cancelar */
        public DateTime? FechaVencimiento { get; set; }
        public int Plazo { get; set; } /*48 hs - C.I*/


    }
}
