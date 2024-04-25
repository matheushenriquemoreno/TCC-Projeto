using FechamentoPedido.Entities.Carrinho;

namespace FechamentoPedido.Services.Interfaces
{
    public interface IServiceProduto
    {
        Task<ProdutoCarinho> AdicionarPedidoViaIntegracao(int idProduto);
        Task<ProdutoCarinho> AtualizarPedidoViaIntegracao(int idProduto);
    }
}
