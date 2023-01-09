using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorMercadoCapitales.Models
{
    public class MensajeRetorno
    {
        public int? cod_mensaje { get; set; }
        public string mensaje { get; set; }
    }

    public class TipoMensaje
    {
        public static MensajeRetorno ObtenerTipoMensaje(string tipo)
        {
            MensajeRetorno retorno = new MensajeRetorno();
            if (tipo == "ErrLogin")
            {
                retorno.cod_mensaje = 99;
                retorno.mensaje = "Usuario y/o clave incorrectos";
            }

            if (tipo == "ErrEncuesta")
            {
                retorno.cod_mensaje = 100;
                retorno.mensaje = "Ocurrio un error al cargar la encuesta";
            }

            return retorno;
        }

    }

}
