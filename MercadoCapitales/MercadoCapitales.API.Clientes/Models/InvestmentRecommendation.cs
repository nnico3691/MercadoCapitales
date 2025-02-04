using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Clientes.Models
{
    public class InvestmentRecommendation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid InstrumentId { get; set; }

        [Required]
        public decimal CommissionPercentage { get; set; }

        [Required]
        public Guid RecommendationId { get; set; } // Clave foránea

        public virtual Recommendation Recommendation { get; set; }
    }

}
