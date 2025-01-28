namespace MercadoCapitales.API.Precios.Models.Dto
{
    public class LastPriceDto
    {
        /// <summary>
        /// Precio del último precio.
        /// </summary>
        public decimal Price { get; set; } // Precio

        /// <summary>
        /// Tamaño del último precio.
        /// </summary>
        public decimal Size { get; set; } // Tamaño

        /// <summary>
        /// Fecha en milisegundos desde la época Unix.
        /// </summary>
        public long Date { get; set; } // Fecha en milisegundos desde la época Unix
    }

}
