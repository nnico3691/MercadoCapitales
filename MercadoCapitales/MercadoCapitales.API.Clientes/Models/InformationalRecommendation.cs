using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Clientes.Models
{
    public class InformationalRecommendation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RecommendationId { get; set; }
        public virtual Recommendation Recommendation { get; set; }

        [Required]
        [MaxLength(1000)]
        public string NewsContent { get; set; } // Contenido de la noticia o análisis
        public string Source { get; set; } // Fuente de la información
    }
}
