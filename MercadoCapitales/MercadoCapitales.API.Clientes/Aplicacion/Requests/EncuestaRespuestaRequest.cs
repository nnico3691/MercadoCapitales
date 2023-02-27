namespace MercadoCapitales.API.Clientes.Aplicacion.Requests
{
    public class EncuestaRespuestaRequest
    {
        public string Respuesta { get; set; }
        public int Puntos { get; set; }
        public string NameInput { get; set; }
        public string TipoInput { get; set; }
    }
}
