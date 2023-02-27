namespace GestorMercadoCapitales.Models
{
    public class Byma
    {
        public string Instrumento { get; set; }
        public float? VolC { get; set; }
        public float? Compra { get; set; }
        public float? Venta { get; set; }
        public float? VolV { get; set; }
        public float? Ult { get; set; }
        public string Var { get; set; }
        public string VarPorcentaje { get; set; }
        public string VolNominal { get; set; }
        public string VolOpe { get; set; }
        public string Cierre { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public string hora { get; set; }
    }
}
