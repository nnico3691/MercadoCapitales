using System.ComponentModel.DataAnnotations;
using System;
using System.Security.Policy;
using System.Collections.Generic;

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
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string TokenRecovery { get; set; }

        // Colección de usuarios primarios relacionados con el cliente
        public ICollection<PrimaryUser> PrimaryUsers { get; set; } = new List<PrimaryUser>();

    }
}
