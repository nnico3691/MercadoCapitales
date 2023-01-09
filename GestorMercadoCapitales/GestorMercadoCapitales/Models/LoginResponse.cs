using System;

namespace GestorMercadoCapitales.Models
{
    public class LoginResponse
    {
        public Guid? loginId { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public Guid? cliente { get; set; }

    }
}
