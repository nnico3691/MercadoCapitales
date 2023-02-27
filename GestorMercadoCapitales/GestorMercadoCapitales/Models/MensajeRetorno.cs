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

            if (tipo == "ErrValidaCompra")
            {
                retorno.cod_mensaje = 101;
                retorno.mensaje = "No se pudo completar la compra/venta del instrumento vuelva a intentarlo";
            }


            if (tipo == "ErrCompraVentamayorcero")
            {
                retorno.cod_mensaje = 102;
                retorno.mensaje = "No se pueden ingresar cantidad y/o precio igual o menor a cero";
            }

            if (tipo == "ErrCargaPrecio")
            {
                retorno.cod_mensaje = 103;
                retorno.mensaje = "No se pudo recargar el precio, favor comuniquese con el área de soporte";
            }

            if (tipo == "ErrConexion")
            {
                retorno.cod_mensaje = 104;
                retorno.mensaje = "Error[500] Desconexión con el servidor, comuníquese con soporte técnico";
            }

            if (tipo == "ErrHorarioMercado")
            {
                retorno.cod_mensaje = 105;
                retorno.mensaje = "Recuerde que el horario de conexión con el mercado es a las ";
            }

            return retorno;
        }

    }

}
