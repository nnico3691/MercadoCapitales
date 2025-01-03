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
        public Guid? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; } // Referencia al objeto Cliente
    }
}
