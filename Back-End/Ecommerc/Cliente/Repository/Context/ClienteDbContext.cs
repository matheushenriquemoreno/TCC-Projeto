using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Repository.Context
{
    public class ClienteDbContext : AppDbContext
    {
        public ClienteDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteDbContext).Assembly);
        }
    }
}
