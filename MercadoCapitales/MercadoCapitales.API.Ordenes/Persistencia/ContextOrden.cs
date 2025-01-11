using MercadoCapitales.API.Ordenes.Models;
using Microsoft.EntityFrameworkCore;
using Primary.Data.Orders;
using Order = MercadoCapitales.API.Ordenes.Models.Order;
using OrderStatus = MercadoCapitales.API.Ordenes.Models.OrderStatus;

namespace MercadoCapitales.API.Ordenes.Persistencia
{
    public class ContextOrden : DbContext
    {
        public ContextOrden() { }
        public ContextOrden(DbContextOptions<ContextOrden> options) : base(options) { }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; } // 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
             .HasMany(o => o.StatusHistory) // Asumiendo que has agregado StatusHistory en Orden
             .WithOne(os => os.Orden) // Relación uno a muchos
             .HasForeignKey(os => os.OrdenId); // Clave foránea en OrderStatus

            base.OnModelCreating(modelBuilder);
        }
    }
}
