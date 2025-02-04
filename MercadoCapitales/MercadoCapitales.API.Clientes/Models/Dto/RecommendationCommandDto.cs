using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoCapitales.API.Clientes.Models.Dto
{
    public class RecommendationCommandDto
    {
        public Guid? Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public InvestmentRiskLevel RiskLevel { get; set; } // Nivel de riesgo asociado a la recomendación
        public Guid AccountExecutiveId { get; set; } // Identificador del cliente al que está dirigida la recomendación

        [NotMapped] // Para que no se almacene en la base de datos
        public RecommendationType? Type { get; set; }

        public ArbitrageRecommendationCommandDto? ArbitrageRecommendation { get; set; } = new ArbitrageRecommendationCommandDto();
        public InformationalRecommendationCommandDto? InformationalRecommendation { get; set; } = new InformationalRecommendationCommandDto();
        public InvestmentRecommendationCommandDto? InvestmentRecommendation { get; set; } = new InvestmentRecommendationCommandDto();
        public PackageRecommendationCommandDto? PackageRecommendation { get; set; } = new PackageRecommendationCommandDto();
    }

    public class ArbitrageRecommendationCommandDto
    {
        public Guid FromInstrumentId { get; set; } // Instrumento actual
        public Guid ToInstrumentId { get; set; } // Instrumento recomendado
        public decimal EstimatedCost { get; set; } // Costo de la operación
    }
    public class InformationalRecommendationCommandDto
    {
        public string NewsContent { get; set; } // Contenido de la noticia o análisis
        public string Source { get; set; } // Fuente de la información
    }
    public class InvestmentRecommendationCommandDto 
    {
        public Guid InstrumentId { get; set; }
        public decimal CommissionPercentage { get; set; }
    }
    public class PackageRecommendationCommandDto
    {
        public virtual ICollection<Guid> Instruments { get; set; }
        public string StrategyName { get; set; } // Nombre de la estrategia predefinida
    }

    public enum RecommendationType
    {
        Arbitrage,
        Informational,
        Investment,
        Package
    }

}
