using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Produto.Repository.Context;

public class ProdutoDbContext : AppDbContext
{
    public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoDbContext).Assembly);
    }
}
