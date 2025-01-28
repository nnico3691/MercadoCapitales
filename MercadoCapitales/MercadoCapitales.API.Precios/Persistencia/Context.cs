using MercadoCapitales.API.Precios.Models;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Precios.Persistencia
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<MarketData> MarketData { get; set; }
        public virtual DbSet<Bid> Bid { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<OpenInterest> OpenInterests { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<LastPrice> LastPrice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>()
                .HasOne(bo => bo.MarketData)
                .WithMany(md => md.BI)
                .HasForeignKey(bo => bo.MarketDataId);

            modelBuilder.Entity<Offer>()
                .HasOne(bo => bo.MarketData)
                .WithMany(md => md.OF)
                .HasForeignKey(bo => bo.MarketDataId);

            modelBuilder.Entity<OpenInterest>()
                .HasOne(oi => oi.MarketData)
                .WithOne(md => md.OI)
                .HasForeignKey<OpenInterest>(oi => oi.MarketDataId);

            modelBuilder.Entity<Settlement>()
                .HasOne(se => se.MarketData)
                .WithOne(md => md.SE)
                .HasForeignKey<Settlement>(se => se.MarketDataId);

            modelBuilder.Entity<LastPrice>()
                .HasOne(se => se.MarketData)
                .WithOne(md => md.LA)
                .HasForeignKey<LastPrice>(se => se.MarketDataId);
        }


    }

}
