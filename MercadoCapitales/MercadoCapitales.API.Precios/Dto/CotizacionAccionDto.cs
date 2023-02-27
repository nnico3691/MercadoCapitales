namespace MercadoCapitales.API.Precios.Dto
{
    public class CotizacionAccionDto
    {
        public string Ticker { get; set; }
        public float? Precio { get; set; }
        public float? VarPorcentual { get; set; }
        public float? PrecioA { get; set; }
        public float? CCompra { get; set; }
        public float? PCompra { get; set; }
        public float? PVenta { get; set; }
        public float? CVenta { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public string Ajuste { get; set; }
        public string VolNom { get; set; }
        public float? Monto { get; set; }
        public int? Oper { get; set; }
        public string Hora { get; set; }
    }
}
