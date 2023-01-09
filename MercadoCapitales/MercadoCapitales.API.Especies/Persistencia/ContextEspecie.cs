using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Especies.Persistencia
{
    public class ContextEspecie : DbContext
    {
        public ContextEspecie() { }
        public ContextEspecie(DbContextOptions<ContextEspecie> options) : base(options) { }
    }
}
