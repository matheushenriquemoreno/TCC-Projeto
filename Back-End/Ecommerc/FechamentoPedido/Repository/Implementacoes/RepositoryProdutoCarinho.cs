using FechamentoPedido.Entities.Carrinho;
using FechamentoPedido.Repository.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repository.Base;

namespace FechamentoPedido.Repository.Implementacoes
{
    public class RepositoryProdutoCarinho : RepositoryBase<ProdutoCarinho>, IRepositoryProdutoCarinho
    {
        public RepositoryProdutoCarinho(FechamentoPedidoContext dbContext) : base(dbContext)
        {
        }
    }
}
