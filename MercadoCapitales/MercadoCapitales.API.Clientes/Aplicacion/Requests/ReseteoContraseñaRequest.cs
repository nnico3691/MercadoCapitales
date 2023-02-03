using System;

namespace MercadoCapitales.API.Clientes.Aplicacion.Requests
{
    public class ReseteoContraseñaRequest
    {
        public Guid? ClienteId { get; set; }
        public string ClaveVieja { get; set; }
        public string ClaveNueva { get; set; }
    }
}
