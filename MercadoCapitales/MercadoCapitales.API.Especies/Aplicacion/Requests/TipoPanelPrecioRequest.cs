namespace MercadoCapitales.API.Especies.Aplicacion.Requests
{
    public class TipoPanelPrecioRequest
    {
        public string cficode { get; set; }
        public string marketSegmentId { get; set; }
        public string Tipo { get; set; }
        public string Mercado { get; set; }
    }
}
