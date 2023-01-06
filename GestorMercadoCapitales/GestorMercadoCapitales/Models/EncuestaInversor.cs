using System.Collections.Generic;

namespace GestorMercadoCapitales.Models
{
    public class EncuestaInversor
    {
        public int id_encuest_pregunt { get; set; }
        public string titulo { get; set; }
        public string preguntas { get; set; }


    }

    public class EncuestaInversorPreg
    {
        public static List<EncuestaInversor> ListaEncuesta;
    }


}
