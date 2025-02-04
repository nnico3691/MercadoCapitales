using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Clientes.Models
{
    public class PackageRecommendation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RecommendationId { get; set; }
        public virtual Recommendation Recommendation { get; set; }
        public virtual ICollection<Guid> Instruments { get; set; }
        public string StrategyName { get; set; } // Nombre de la estrategia predefinida
    }
}
