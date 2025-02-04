using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercadoCapitales.API.Clientes.Models
{
    public class Recommendation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public InvestmentRiskLevel RiskLevel { get; set; } // Nivel de riesgo asociado a la recomendación

        [Required]
        public Guid AccountExecutiveId { get; set; } // Identificador del cliente al que está dirigida la recomendación
        public virtual AccountExecutive AccountExecutive { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public virtual InvestmentRecommendation? InvestmentRecommendation { get; set; }
        public virtual ArbitrageRecommendation? ArbitrageRecommendation { get; set; };
    }

    public enum InvestmentRiskLevel
    {
        Low,
        Medium,
        High
    }
}
