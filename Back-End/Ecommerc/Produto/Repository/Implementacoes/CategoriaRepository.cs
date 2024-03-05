using Infra.Data.Context;
using Infra.Data.Repository.Base;
using Produto.Entities;
using Produto.Repository.Interfaces;

namespace Produto.Repository.Implementacoes
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
