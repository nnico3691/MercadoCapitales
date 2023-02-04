using Microsoft.Extensions.Primitives;

namespace MercadoCapitales.API.Clientes.Modelo
{
    public class MailRequest
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
