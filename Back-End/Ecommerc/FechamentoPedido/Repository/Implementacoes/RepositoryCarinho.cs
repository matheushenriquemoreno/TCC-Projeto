using FechamentoPedido.Entities.Carrinho;
using FechamentoPedido.Repository.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repository.Base;

namespace FechamentoPedido.Repository.Implementacoes;

public class RepositoryCarinho : RepositoryBase<CarinhoCompra>, IRepositoryCarinho
{
    public RepositoryCarinho(FechamentoPedidoContext dbContext) : base(dbContext)
    {
    }
}
