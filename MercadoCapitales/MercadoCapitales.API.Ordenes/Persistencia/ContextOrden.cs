using MercadoCapitales.API.Ordenes.Modelo;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Ordenes.Persistencia
{
    public class ContextOrden : DbContext
    {
        public ContextOrden() { }
        public ContextOrden(DbContextOptions<ContextOrden> options) : base(options) { }
        public virtual DbSet<Orden> Orden { get; set; }
    }
}
