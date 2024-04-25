using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FechamentoPedido.Repository
{
    public class FechamentoPedidoContext : AppDbContext
    {
        public FechamentoPedidoContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FechamentoPedidoContext).Assembly);
        }
    }
}
