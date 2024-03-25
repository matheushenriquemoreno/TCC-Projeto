using Infra.Data.Context;
using Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Produto.Entities;
using Produto.Repository.Interfaces;

namespace Produto.Repository.Implementacoes;

public class ProdutoRepository : RepositoryBase<Entities.Produto>, IRepositoryProduto
{
    public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override Task<Entities.Produto> Atualizar(Entities.Produto entidade)
    {
        var dados = _context.Set<Imagem>().Where(x => x.IdProduto == entidade.Id);

        _context.Set<Imagem>().RemoveRange(dados);

        return base.Atualizar(entidade);
    }
}
