using MercadoCapitales.API.Clientes.Modelo;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Clientes.Persistencia
{
    public class ContextCliente : DbContext
    {
        public ContextCliente() { }
        public ContextCliente(DbContextOptions<ContextCliente> options) : base(options) { }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
    }
}
