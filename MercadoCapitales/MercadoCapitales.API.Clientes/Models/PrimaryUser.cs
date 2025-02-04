using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MercadoCapitales.API.Clientes.Models
{
    public class PrimaryUser
    {
        [Key]
        public Guid Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }

        // Propiedad de navegación para relacionar con Cliente
        public Guid? ClienteId { get; set; } // Clave foránea opcional
        public virtual Cliente Cliente { get; set; } // Referencia al objeto Cliente

        // Propiedad de navegación para relacionar con las posiciones
        public virtual ICollection<Position> Positions { get; set; } = new List<Position>(); // Relación uno a muchos
    }
}
