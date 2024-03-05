using Infra.Data.Context;
using Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Produto.Repository.Interfaces;

namespace Produto.Repository.Implementacoes;

public class ProdutoRepository : RepositoryBase<Entities.Produto>, IRepositoryProduto
{
    public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
