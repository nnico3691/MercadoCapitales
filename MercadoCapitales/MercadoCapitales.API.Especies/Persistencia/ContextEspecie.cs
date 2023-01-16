using MercadoCapitales.API.Especies.Modelo;
using Microsoft.EntityFrameworkCore;
using Primary.Data.Orders;

namespace MercadoCapitales.API.Especies.Persistencia
{
    public class ContextEspecie : DbContext
    {
        public ContextEspecie() { }
        public ContextEspecie(DbContextOptions<ContextEspecie> options) : base(options) { }
        public virtual DbSet<Instrumento> Instrumento { get; set; }
        public virtual DbSet<InstrumentOrderType> InstrumentOrderType { get; set; }
        public virtual DbSet<InstrumentTimeInForce> InstrumentTimeInForce { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
    }
}
