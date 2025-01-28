using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Especies.Models
{
    public class FuturoFinanciero
    {
        [Key]
        public Guid? FuturoFinancieroId { get; set; }
        public Guid? ProductoGroupId { get; set; }
    }
}
