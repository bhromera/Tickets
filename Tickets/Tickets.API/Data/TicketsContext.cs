using Microsoft.EntityFrameworkCore;
using Tickets.API.Data.Models.Mapping;
using Tickets.Application.Data.Models;

namespace Tickets.API.Data
{
    public partial class TicketsContext : DbContext
    {
        public TicketsContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Ingresso> Ingresso { get; set; }
        public DbSet<ItensCarrinho> ItensCarrinho { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketsContext).Assembly);

            modelBuilder.ApplyConfiguration(new ItensCarrinhoConfiguration());

            //modelBuilder.Entity<ItensCarrinho>(a =>
            //{
            //    a.HasNoKey();
            //});
        }
    }
}
