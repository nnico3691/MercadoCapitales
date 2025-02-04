using System;

namespace MercadoCapitales.API.Clientes.Models.Dto
{
    public class RecommendationQueryDto
    {
        public Guid? Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public InvestmentRiskLevel RiskLevel { get; set; } // Nivel de riesgo asociado a la recomendación
        public Guid AccountExecutiveId { get; set; } // Identificador del cliente al que está dirigida la recomendación
        public InvestmentRecommendationQueryDto? InvestmentRecommendation { get; set; } = new InvestmentRecommendationQueryDto();
    }
    public class InvestmentRecommendationQueryDto
    {
        public Guid? Id { get; set; }
        public InstrumentDto InstrumentDto { get; set; }
        public decimal CommissionPercentage { get; set; }
    }
    
}
