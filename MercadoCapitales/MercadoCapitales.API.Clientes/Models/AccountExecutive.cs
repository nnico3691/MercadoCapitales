using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MercadoCapitales.API.Clientes.Models
{
    public class AccountExecutive
    {
        public Guid Id { get; set; } // Identificador único

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Nombre del operador

        [MaxLength(100)]
        public string Email { get; set; } // Correo electrónico (opcional)

        [MaxLength(15)]
        public string PhoneNumber { get; set; } // Número de teléfono (opcional)

        [Required]
        public OrganizationType Organization { get; set; } // Interno o Externo

        [Required]
        public bool Recommender { get; set; } // Si es recomendador
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }

        public virtual List<Recommendation> Recommendations { get; set; } = new List<Recommendation>(); // Lista de recomendaciones generales que pueden ser de diferentes tipos
    }

    public enum OrganizationType
    {
        Interno = 0,
        Externo = 1
    }

}
