using MercadoCapitales.API.Especies.Models;
using Microsoft.EntityFrameworkCore;
using Primary.Data.Orders;
using System.Security.Cryptography;
using System;

namespace MercadoCapitales.API.Especies.Persistencia
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public virtual DbSet<Instrument> Instrument { get; set; }
        public virtual DbSet<InstrumentOrderType> InstrumentOrderType { get; set; }
        public virtual DbSet<InstrumentTimeInForce> InstrumentTimeInForce { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstrumentOrderType>()
                .HasOne(bo => bo.Instrument)
                .WithMany(md => md.InstrumentOrderType)
                .HasForeignKey(bo => bo.InstrumentId);

            modelBuilder.Entity<InstrumentTimeInForce>()
                .HasOne(bo => bo.Instrument)
                .WithMany(md => md.InstrumentTimeInForce)
                .HasForeignKey(bo => bo.InstrumentId);

        }
    }
}
