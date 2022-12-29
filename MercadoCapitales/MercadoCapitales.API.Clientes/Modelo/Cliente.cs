using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Clientes.Modelo
{
    public class Cliente
    {
        [Key]
        public Guid? ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDNI { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }

    }
}
