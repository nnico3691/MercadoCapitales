using System.Collections.Generic;

namespace GestorMercadoCapitales.Models
{
    public class MtbaRfx : MensajeRetorno
    {
        public string Instrumento { get; set; }
        public decimal? VolC { get; set; }
        public decimal? Compra { get; set; }
        public decimal? Venta { get; set; }
        public decimal? VolV { get; set; }
        public float? Ult { get; set; }
        public string Var { get; set; }
        public string VarPorcentaje { get; set; }
        public decimal? VolOpe { get; set; }
        public string Ajuste { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public float? intAbierto { get; set; }
        public string TNA { get; set; }
        public string hora { get; set; }

       public string ColorVenta { get; set; }
        public string ColorCompra { get; set; }

    }

    public class RofexList
    {
        public static List<MtbaRfx> rfxlist = new List<MtbaRfx>();

        public static void LimpiarMensaje()
        {
            rfxlist[0].cod_mensaje = 0;
            rfxlist[0].mensaje = "";
        }


    }
    


}
