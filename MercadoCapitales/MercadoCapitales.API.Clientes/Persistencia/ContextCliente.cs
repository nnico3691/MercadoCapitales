using MercadoCapitales.API.Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Clientes.Persistencia
{
    public class ContextCliente : DbContext
    {
        public ContextCliente() { }
        public ContextCliente(DbContextOptions<ContextCliente> options) : base(options) { }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClienteEncuestas> ClienteEncuestas { get; set; }
        public virtual DbSet<EncuestaPregunta> EncuestaPregunta { get; set; }
        public virtual DbSet<EncuestaRespuesta> EncuestaRespuesta { get; set; }
        public virtual DbSet<ClientePerfilInversor> ClientePerfilInversor { get; set; }
        public virtual DbSet<PrimaryUser> PrimaryUser { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<AccountExecutive> AccountExecutive { get; set; }
        public virtual DbSet<Recommendation> Recommendation { get; set; }
        public virtual DbSet<InvestmentRecommendation> InvestmentRecommendation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recommendation>()
             .HasOne(r => r.InvestmentRecommendation)  // Relación 1 a 1
             .WithOne(ir => ir.Recommendation)
             .HasForeignKey<InvestmentRecommendation>(ir => ir.RecommendationId)
             .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }

    }
}
