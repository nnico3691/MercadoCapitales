using System.ComponentModel.DataAnnotations;
using System;

namespace MercadoCapitales.API.Especies.Modelo
{
    public class ProductGroup
    {
        [Key]
        public Guid? ProductGroupId { get; set; }
        public string Descripcion { get; set; }
        public string Mercado { get; set; }
    }
}
