using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Clientes.Models
{
    public class ArbitrageRecommendation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RecommendationId { get; set; }
        public virtual Recommendation Recommendation { get; set; }

        [Required]
        public Guid FromInstrumentId { get; set; } // Instrumento actual

        [Required]
        public Guid ToInstrumentId { get; set; } // Instrumento recomendado

        public decimal EstimatedCost { get; set; } // Costo de la operación
    }
}
