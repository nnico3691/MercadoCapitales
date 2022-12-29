using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Clientes.Modelo
{
    public class Login
    {
        [Key]
        public Guid? LoginId { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public Guid? Cliente { get; set; }
    }
}
