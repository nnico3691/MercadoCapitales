using MercadoCapitales.API.Precios.Modelo;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Precios.Persistencia
{
    public class ContextPrecio : DbContext
    {
        public ContextPrecio() { }
        public ContextPrecio(DbContextOptions<ContextPrecio> options) : base(options) { }
        public virtual DbSet<CotizacionAccion> CotizacionAccion { get; set; }

    }
}
