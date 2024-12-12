using MercadoCapitales.API.Ordenes.Modelo;
using Microsoft.EntityFrameworkCore;
using Primary.Data.Orders;
using OrderStatus = MercadoCapitales.API.Ordenes.Modelo.OrderStatus;

namespace MercadoCapitales.API.Ordenes.Persistencia
{
    public class ContextOrden : DbContext
    {
        public ContextOrden() { }
        public ContextOrden(DbContextOptions<ContextOrden> options) : base(options) { }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; } // 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orden>()
             .HasMany(o => o.StatusHistory) // Asumiendo que has agregado StatusHistory en Orden
             .WithOne(os => os.Orden) // Relación uno a muchos
             .HasForeignKey(os => os.OrdenId); // Clave foránea en OrderStatus

            base.OnModelCreating(modelBuilder);
        }
    }
}
