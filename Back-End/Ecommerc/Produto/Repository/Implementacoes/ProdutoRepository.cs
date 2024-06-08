using Infra.Data.Context;
using Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Produto.Entities;
using Produto.Repository.Interfaces;
using static Produto.Entities.Produto;


namespace Produto.Repository.Implementacoes;

public class ProdutoRepository : RepositoryBase<Entities.Produto>, IRepositoryProduto
{
    public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<Produto> Atualizar(Entities.Produto entidade)
    {
        _context.Update(entidade);
        await _context.SaveChangesAsync();
    }
}
